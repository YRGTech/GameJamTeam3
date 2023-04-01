using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float damage;
    [SerializeField] float followSpeed;
    public event Action OnDestroy;


    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Apubal()
    {
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }
}