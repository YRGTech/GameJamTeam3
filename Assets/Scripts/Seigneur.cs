using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seigneur : MonoBehaviour
{
    public int Hp = 1000;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Hp -= other.gameObject.GetComponent<Enemy>().damage;
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
}
