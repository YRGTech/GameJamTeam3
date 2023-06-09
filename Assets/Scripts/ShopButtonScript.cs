using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ShopButtonScript : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;
    private SpriteRenderer rend;
    private GameObject turret;
    [SerializeField] int price;

    public GameObject turret1;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    [SerializeField] NodeScript nodeScript;

    [SerializeField] TextMeshPro priceText;



    public AudioClip builded;

    private CurrencyManager currencyManager;
    private int playerId;

    void Start()
    {
        priceText.text = price.ToString();
        currencyManager = FindObjectOfType<CurrencyManager>();
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }
    private void Update()
    {
        NodeScript node = GetComponentInParent<NodeScript>();
        if (node != null)
        {
            playerId = node.playerId;
        }
    }

    private void OnMouseDown()
    {
        FindObjectOfType<SoundManager>().ClickSound();

        if (turret != null || playerId != FindObjectOfType<GameManager>().turnPlayer)
        {
            Debug.Log("Impossible de construire ici, il y a déja une tourelle.");
            return;
        }


        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        if (currencyManager.CheckCurrency(playerId) >= price)
        {

            GameObject newObject = Instantiate(turret1, transform.parent.position + new Vector3(0, 0.5f), transform.rotation);
            nodeScript.turret = newObject;
            newObject.GetComponent<Tower>().ownerId= playerId;
            newObject.transform.SetParent(GetComponentInParent<NodeScript>().transform);

            currencyManager.AddCurrency(-price, playerId);

            FindObjectOfType<SoundManager>().Builded( builded);

            GameManager.Destroy(button1);
            GameManager.Destroy(button2);
            GameManager.Destroy(button3);
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





