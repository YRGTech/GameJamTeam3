using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float followSpeed;

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
}