using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class NodeScript : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;
    private SpriteRenderer rend;
    public GameObject turret;

    bool turretPosed;

    

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turretPosed)
        {
            Debug.Log("Impossible de construire ici, il y a déja une tourelle.");
            return;
        }

        Instantiate(turret, transform.position, transform.rotation);
        turretPosed = true;
    }

    private void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}





