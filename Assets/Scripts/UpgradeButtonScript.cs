    using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.WSA;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class UpgradeButtonScript : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;
    private SpriteRenderer rend;
    private GameObject turret;
    [SerializeField] int price;
    [SerializeField] int level = 1;

    private GameObject projectilePrefabLevel2;
    private GameObject projectilePrefabLevel3;

    public GameObject turret1;

    [SerializeField] NodeScript nodeScript;

    [SerializeField] TextMeshPro priceText;

    private Sprite spriteLevel2;
    private Sprite spriteLevel3;

    private CurrencyManager currencyManager;
    private int playerId;

    void Start()
    {
        projectilePrefabLevel2 = nodeScript.turret.GetComponent<TowerShoot>().projectilePrefabLevel2;
        projectilePrefabLevel3 = nodeScript.turret.GetComponent<TowerShoot>().projectilePrefabLevel3;

        spriteLevel2 = nodeScript.turret.GetComponent<TowerShoot>().spriteLevel2;
        spriteLevel3 = nodeScript.turret.GetComponent<TowerShoot>().spriteLevel3;

        price = nodeScript.turret.GetComponent<TowerShoot>().price;
        turret1 = nodeScript.turret;

        currencyManager = FindObjectOfType<CurrencyManager>();
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;


    }
    private void Update()
    {
        priceText.text = (price*2).ToString();
        UnityEngine.Debug.Log(level);
        Tower tower = GetComponentInChildren<Tower>();
        if (tower != null)
        {
            playerId = tower.ownerId;
        }
    }

    private void OnMouseDown()
    {


        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        if (currencyManager.CheckCurrency(playerId) >= price*2)
        {

            price = price * 2;
            currencyManager.AddCurrency(-price, playerId);
            level++;


            if (level == 2)
            {
                nodeScript.turret.GetComponent<TowerShoot>().turretLevel1.SetActive(false);
                nodeScript.turret.GetComponent<TowerShoot>().turretLevel2.SetActive(true);
                nodeScript.turret.GetComponent<SpriteRenderer>().sprite = spriteLevel2;
                nodeScript.turret.GetComponent<TowerShoot>().projectilePrefab = projectilePrefabLevel2;
            }


            if (level == 3)
            {
                nodeScript.turret.GetComponent<TowerShoot>().turretLevel2.SetActive(false);
                nodeScript.turret.GetComponent<TowerShoot>().turretLevel3.SetActive(true);
                nodeScript.turret.GetComponent<SpriteRenderer>().sprite = spriteLevel3;
                nodeScript.turret.GetComponent<TowerShoot>().projectilePrefab = projectilePrefabLevel3;
                nodeScript.level = level;
                GameManager.Destroy(gameObject);
            }

            gameObject.SetActive(false);
        }
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





