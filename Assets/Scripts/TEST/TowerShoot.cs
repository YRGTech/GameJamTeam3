using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float range;
    private float lastShotTime;
    private List<GameObject> pooledProjectiles;
    private GameObject currentTarget;

    void Start()
    {
        pooledProjectiles = new List<GameObject>();
    }

    void Update()
    {
        if (currentTarget != null)
        {
            if (Vector3.Distance(transform.position, currentTarget.transform.position) <= range)
            {
                if (Time.time - lastShotTime > timeBetweenShots)
                {
                    FireProjectile(currentTarget);
                    lastShotTime = Time.time;
                }
            }
            else
            {
                currentTarget = null;
            }
        }
        else
        {
            Vector2 enemyPos = transform.position;
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(enemyPos, range);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Enemy"))
                {
                    currentTarget = hitCollider.gameObject;
                    break;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            currentTarget = other.gameObject;
        }
    }

    void FireProjectile(GameObject target)
    {
        if (Time.time - lastShotTime > timeBetweenShots)
        {
            GameObject projectileInstance = GetPooledProjectile();
            if (projectileInstance == null)
            {
                projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                pooledProjectiles.Add(projectileInstance);
            }
            projectileInstance.SetActive(true);
            projectileInstance.transform.position = transform.position;
            Projectile circleScript = projectileInstance.GetComponent<Projectile>();
            if (circleScript != null)
            {
                circleScript.target = target.transform;
            }
            lastShotTime = Time.time;
        }
    }

    GameObject GetPooledProjectile()
    {
        for (int i = 0; i < pooledProjectiles.Count; i++)
        {
            if (!pooledProjectiles[i].activeInHierarchy)
            {
                return pooledProjectiles[i];
            }
        }
        return null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
