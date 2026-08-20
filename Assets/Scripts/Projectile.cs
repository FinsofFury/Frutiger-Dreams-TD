using System.Diagnostics.Contracts;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float speed = 15f;
    public int damage = 50;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        // destroy bullet if enemy dies before it reaches
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //direction and dist
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.LookAt(target);
    }

    void HitTarget()
    {
        // enemy now takes damage
        Enemy enemy = target.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
