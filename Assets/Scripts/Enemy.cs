using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float speed = 5f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        if (Waypoints.wayPoints.Length > 0)
        {
            target = Waypoints.wayPoints[0];
        }
    }

    void Update()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.wayPoints.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.wayPoints[waypointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
    }
}
