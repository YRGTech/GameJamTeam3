using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallController : MonoBehaviour
{
    public GameObject[] zone;
    public int health = 500;
    private int startHealth;
    public int ownerId;
    private Tilemap map;
    private bool hasChangedSide;
    private void Start()
    {
        map = GetComponent<Tilemap>();
        startHealth = health;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                health -= enemy.damage;
            }
            enemy.Die();
        }
    }

    private void Update()
    {
        int towerId = zone[0].GetComponentInChildren<NodeScript>().playerId;
        ownerId = towerId;

        if (health <= 0 && !hasChangedSide)
        {
            foreach (var node in zone)
            {
                node.GetComponent<NodeScript>().playerId = (ownerId + 1) % FindObjectOfType<GameManager>().numPlayers;
                Tower tower = node.GetComponentInChildren<Tower>();
                if (tower != null)
                {
                    tower.ownerId = (ownerId + 1) % FindObjectOfType<GameManager>().numPlayers;

                }
            }
            GameManager gameManager = FindObjectOfType<GameManager>();
            ownerId = (gameManager.turnPlayer + 1) % gameManager.numPlayers;
            hasChangedSide = true;
        }

        switch (ownerId)
        {
            case 0:
                map.color = Color.red;
                break;
            case 1:
                map.color = Color.white;
                break;
            default:
                break;
        }
    }
    public void resetHp()
    {
        if (hasChangedSide)
        {
            health = startHealth;
            hasChangedSide = false;
        }
    }
}
