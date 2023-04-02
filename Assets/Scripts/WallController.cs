using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using CodeMonkey.HealthSystemCM;
public class WallController : MonoBehaviour, IGetHealthSystem
{
    public GameObject[] zone;
    public int health = 500;
    private int startHealth;
    public int ownerId;
    private Tilemap map;
    private bool hasChangedSide;

    private HealthSystem healthSystem;
    private void Awake()
    {
        map = GetComponent<Tilemap>();
        healthSystem = new HealthSystem(health);
        startHealth = health;
    }

    public void Damage(float damage)
    {
        healthSystem.Damage(damage);
        health = (int)healthSystem.GetHealth();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                Damage(enemy.damage);
            }
            FindObjectOfType<SoundManager>().DeadSound();
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
            healthSystem.HealComplete();
            health = (int)healthSystem.GetHealth();
            hasChangedSide = false;
        }
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
