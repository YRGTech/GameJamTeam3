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
    private Renderer rend;
    public GameObject turret;

    bool turretPosed;

    

    void Start()
    {
        rend = GetComponent<Renderer>();
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

    private void OnMouseOver()
    {
        rend.material.color = Color.red;
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}





