using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed;
    [SerializeField] float timeBetweenShots;
    private float lastShotTime;
    private List<GameObject> pooledProjectiles;

    void Start()
    {
        pooledProjectiles = new List<GameObject>();
    }

    void Update()
    {
        if (Time.time - lastShotTime > timeBetweenShots)
        {
            FireProjectile();
            lastShotTime = Time.time;
        }
    }

    void FireProjectile()
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
            circleScript.target = GameObject.FindGameObjectWithTag("Enemy").transform;
            circleScript.followSpeed = projectileSpeed;
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
}
