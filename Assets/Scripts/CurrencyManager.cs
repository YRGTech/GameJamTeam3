using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int startingCurrency = 100;
    private int currentCurrency;

    void Start()
    {
        currentCurrency = startingCurrency;
    }

    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
    }


}
