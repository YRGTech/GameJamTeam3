using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seigneur : MonoBehaviour, IGetHealthSystem
{
    public int Hp = 1000;
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = new HealthSystem(Hp);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            healthSystem.Damage( other.gameObject.GetComponent<Enemy>().damage);
            Hp = (int)healthSystem.GetHealth();
            other.GetComponent<Enemy>().Die();
        }
    }

    private void Update()
    {
        if (Hp <= 0)
        {
            GameManager.isOver = true;
        }
    }
    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
