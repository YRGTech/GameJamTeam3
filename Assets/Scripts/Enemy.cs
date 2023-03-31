
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;


    private void Start()
    {
        target = Waypoints.points[0];

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized,Space.World);

        if (Vector3.Distance(transform.position,target.position)<= 0.2)
        {
            GetNextWaypoint();
        }
    }
    private void GetNextWaypoint()
    {
        EndPath();
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    private void EndPath()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
    }
}
