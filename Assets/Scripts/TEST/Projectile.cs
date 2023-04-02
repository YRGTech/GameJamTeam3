using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float damage;
    public float followSpeed;
    public event Action OnDestroy;
    public int playerId;

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }
        else
        {
            Apubal();
        }
    }

    public void Apubal()
    {
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage,playerId);
            Apubal();
        }
    }
}