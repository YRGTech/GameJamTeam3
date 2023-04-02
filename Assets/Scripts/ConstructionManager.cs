using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{

    [SerializeField] GameObject fonde;
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] TowerShoot towerShoot;
    [SerializeField] float startTime;

    void Start()
    {
        startTime = Time.time + 4.5f;
        renderer.enabled = false;
        towerShoot.enabled = false;
        fonde.SetActive(false);
    }

    void Update()
    {
        if (Time.time >= startTime)
        {
            renderer.enabled = true;
            towerShoot.enabled = true;
            fonde.SetActive(true);
        }
        if (Time.time >= startTime + 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
