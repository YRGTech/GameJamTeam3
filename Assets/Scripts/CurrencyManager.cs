using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int startingCurrency = 100;

    [SerializeField]
    private TextMeshProUGUI moneyText;
    private int currentCurrency;

    void Start()
    {
        currentCurrency = startingCurrency;
    }

    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
    }

    private void Update()
    {
        moneyText.text = "Money : " + currentCurrency;
    }

}
