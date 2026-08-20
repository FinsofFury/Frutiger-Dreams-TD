using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float speed = 5f;
    public float startHealth = 100f;
    private float currentHealth;

    [Header("Unity Stuff")]
    public GameObject healthBarObject;
    private Image healthBar;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        currentHealth = startHealth;

        healthBar = healthBarObject.GetComponent<Image>();

        if (Waypoints.wayPoints.Length > 0)
        {
            target = Waypoints.wayPoints[0];
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.fillAmount = currentHealth / startHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
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
        PlayerStats.Lives--;

        Destroy(gameObject);
    }
}
