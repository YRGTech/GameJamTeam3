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
    private GameObject turret;


    

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret !=null)
        {
            Debug.Log("Impossible de construire ici, il y a déja une tourelle.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild,transform.position, transform.rotation);
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





