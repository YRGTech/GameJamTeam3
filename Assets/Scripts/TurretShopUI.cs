using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretShopUI : MonoBehaviour
{

    public GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("Tower");

    void Start()
    {
        // Créer un bouton pour chaque tourelle
        foreach (GameObject object in gameobjects)
        {
            GameObject shopItem = Instantiate(shopItemPrefab, shopItemParent);
            shopItem.transform.Find("Name").GetComponent<Text>().text = turretData.name;
            shopItem.transform.Find("Price").GetComponent<Text>().text = "$" + turretData.price.ToString();
            shopItem.transform.Find("Description").GetComponent<Text>().text = turretData.description;
            shopItem.transform.Find("BuyButton").GetComponent<Button>().onClick.AddListener(() => BuyTurret(turretData));
        }


}
