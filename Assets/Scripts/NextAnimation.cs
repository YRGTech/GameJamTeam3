using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAnimation : MonoBehaviour
{

    public Animator animator;
    private float timeActuelle;
    private bool isIdle = true;
    [SerializeField] float timeDelay;

    void Start()
    {

    }

    void Update()
    {
        
        if (!isIdle && timeActuelle <= Time.time - 1.15f)
        {
            isIdle = true;
            animator.SetBool("isShooting", false);
        }
    }


    public void PlayAnim()
    {
        animator.SetBool("isShooting", true);
        timeActuelle = Time.time;
        isIdle = false;
    }
}
