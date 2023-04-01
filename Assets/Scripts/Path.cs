using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    public int GetWaypointCount()
    {
        return waypoints.Length;
    }

    public Vector3 GetWaypoint(int index)
    {
        return waypoints[index].position;
    }

    private void OnDrawGizmos()
    {
        // Draw lines between waypoints in the editor
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}
