using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallController : MonoBehaviour
{
    public GameObject[] zone;
    public int health = 500;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                health -= enemy.damage;
                Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            foreach (var node in zone)
            {
                Tower tower = node.GetComponentInChildren<Tower>();
                if (tower != null)
                {
                    int currentOwner = tower.ownerId;
                   tower.ownerId = (currentOwner + 1) % FindObjectOfType<GameManager>().numPlayers;

                }
            }
            gameObject.SetActive(false);

        }
    }
}
