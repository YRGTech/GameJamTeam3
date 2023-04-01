using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAnimation : MonoBehaviour
{

    public Animator animator;
    private float timeActuelle;
    private bool isIdle = true;

    void Start()
    {

    }

    void Update()
    {
        
        if (!isIdle && timeActuelle <= Time.time - 1.15f)
        {
            isIdle = true;
            animator.Play("Fonde 1 Idle");
        }
    }


    private void PlayAnim()
    {
        animator.Play("Fonde 1");
        timeActuelle = Time.time;
        isIdle = false;
    }
}
