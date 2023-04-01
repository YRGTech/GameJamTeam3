
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float speed = 10f;
    public int damage = 50;
    public int currencyReward = 10;
    private Vector3 target;
    private int waypointIndex = 0;
    private Path path;
    CurrencyManager currencyManager;

    public event Action OnDeath;
    public Animator animator;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
    }
    public void SetPath(Path path)
    {
        this.path = path;
        
        // Start moving towards the first waypoint
        waypointIndex = 0;
        target = path.GetWaypoint(waypointIndex);

    }
    private void Update()
    {
        if (path == null)
            return;
        else
        {

            Vector3 dir = target - transform.position;


            if (dir != Vector3.zero)
            {
                dir = dir.normalized; // Normalize the direction vector
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                if (angle < 0)
                {
                    angle += 360;
                }
                // angle is now the angle in degrees between the transform and the target
                if (angle >= 45 && angle < 135)
                {
                    if (!animator.GetBool("IsWalkingUp"))
                    {
                        animator.SetBool("IsWalkingUp", true);
                        animator.SetBool("IsWalkingRight", false);
                        animator.SetBool("IsWalkingDown", false);
                        animator.SetBool("IsWalkingLeft", false);
                    }
                }
                else if (angle >= 135 && angle < 225)
                {
                    if (!animator.GetBool("IsWalkingLeft"))
                    {
                        animator.SetBool("IsWalkingLeft", true);
                        animator.SetBool("IsWalkingRight", false);
                        animator.SetBool("IsWalkingDown", false);
                        animator.SetBool("IsWalkingUp", false);
                    }
                }
                else if (angle >= 225 && angle < 315)
                {
                    if (!animator.GetBool("IsWalkingDown"))
                    {
                        animator.SetBool("IsWalkingDown", true);
                        animator.SetBool("IsWalkingRight", false);
                        animator.SetBool("IsWalkingLeft", false);
                        animator.SetBool("IsWalkingUp", false);
                    }
                }
                else
                {
                    if (!animator.GetBool("IsWalkingRight"))
                    {
                        animator.SetBool("IsWalkingRight", true);
                        animator.SetBool("IsWalkingDown", false);
                        animator.SetBool("IsWalkingLeft", false);
                        animator.SetBool("IsWalkingUp", false);
                    }
                }
            }
            transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
        }



        if (Vector3.Distance(transform.position, target) <= 0.2)
        {
            GetNextWaypoint();
        }
    }
    public void TakeDamage(float damage)
    {
        health -= Mathf.RoundToInt( damage);

        if (health <= 0)
        {
            currencyManager.AddCurrency(currencyReward);
            Die();
        }
    }
    private void GetNextWaypoint()
    {
        if (waypointIndex >= path.GetWaypointCount())
        {
            return;

        }
        target = path.GetWaypoint(waypointIndex);

        waypointIndex++;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            currencyManager.AddCurrency(currencyReward);
            Die();
        }
    }


    public void Die()
    {
        // Trigger the OnDeath event
        OnDeath?.Invoke();


        Destroy(gameObject);

        Debug.Log(currencyReward);
    }


   
}
