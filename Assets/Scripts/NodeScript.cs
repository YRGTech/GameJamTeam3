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

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    private CurrencyManager currencyManager;
    public int playerId;

    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }
    private void Update()
    {
        Tower tower = GetComponentInChildren<Tower>();
        if (tower != null)
        {
            playerId = tower.ownerId;

        }
    }

    private void OnMouseDown()
    {
        if (turret == null)
        {
            Button1.SetActive(!Button1.activeSelf);
            Button2.SetActive(!Button2.activeSelf);
            Button3.SetActive(!Button3.activeSelf);
        }

        

                if (turret != null || playerId != FindObjectOfType<GameManager>().turnPlayer)

        {
            Debug.Log("Impossible de construire ici, il y a déja une tourelle.");
            return;
        }


            //GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            //if (currencyManager.CheckCurrency(playerId) >= 20)
            //{
            //    turret = Instantiate(turretToBuild, transform.position + new Vector3(0, 0.5f), transform.rotation);
            //    turret.transform.parent = transform;
            //    currencyManager.AddCurrency(-20, playerId);
            //}
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





