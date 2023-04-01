using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EndPath : MonoBehaviour
{
    Vassal vassal;

    private void Start()
    {
        vassal= FindObjectOfType<Vassal>().GetComponent<Vassal>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            vassal.pv -= other.GetComponent<Enemy>().damage;
        }
    }
}
