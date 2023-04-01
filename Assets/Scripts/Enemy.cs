
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pv = 10;
    public float speed = 10f;
    public int damage = 50;
    public int currencyReward = 10;
    private Transform target;
    private int waypointIndex = 0;

    CurrencyManager currencyManager;

    private void Start()
    {
        target = Waypoints.points[0];
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2)
        {
            GetNextWaypoint();
        }

        if(pv<=0)
        {
            Killed();
        }
    }
    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;

        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    private void EndPath()
    {
            Destroy(gameObject);
    }

    public void Killed()
    {
        currencyManager.AddCurrency(currencyReward);
        Destroy(gameObject);

        Debug.Log(currencyReward);
    }
}
