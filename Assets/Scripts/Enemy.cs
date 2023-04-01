
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float speed = 10f;
    public int damage = 50;
    public int currencyReward = 10;
    private Vector3 target;
    private int waypointIndex = 0;
    private Path path;
    CurrencyManager currencyManager;

    public event Action OnDeath;

    private void Start()
    {

        currencyManager = FindObjectOfType<CurrencyManager>();
    }
    public void SetPath(Path path)
    {
        this.path = path;
        
        // Start moving towards the first waypoint
        waypointIndex = 0;
        target = path.GetWaypoint(waypointIndex);

    }
    private void Update()
    {
        if (path == null)
            return;
        else
        {

            Vector3 dir = target - transform.position;
            transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
        }

        if (Vector3.Distance(transform.position, target) <= 0.2)
        {
            GetNextWaypoint();
        }
    }
    public void TakeDamage(float damage)
    {
        health -= Mathf.RoundToInt( damage);

        if (health <= 0)
        {
            currencyManager.AddCurrency(currencyReward);
            Die();
        }
    }
    private void GetNextWaypoint()
    {
        if (waypointIndex >= path.GetWaypointCount())
        {
            return;

        }
        target = path.GetWaypoint(waypointIndex);

        waypointIndex++;
    }


    public void Die()
    {
        // Trigger the OnDeath event
        OnDeath?.Invoke();


        Destroy(gameObject);

        Debug.Log(currencyReward);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(other.GetComponent<Projectile>().damage);
            other.GetComponent<Projectile>().Apubal();
        }
    }
}
