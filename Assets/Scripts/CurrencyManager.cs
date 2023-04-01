using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int startingCurrency = 100;

    [SerializeField]
    private TextMeshProUGUI player1MoneyText;
    private int player1Currency;

    [SerializeField]
    private TextMeshProUGUI player2MoneyText;
    private int player2Currency;


    void Start()
    {
        player1Currency = startingCurrency;
        player2Currency = startingCurrency;

    }

    public void AddCurrency(int amount, int player)
    {
        if (player == 1)
        {
            player1Currency += amount;
        }
        else if (player == 2)
        {
            player2Currency += amount;
        }
    }


    private void Update()
    {
        player1MoneyText.text = "Player 1 Money: " + player1Currency;
        player2MoneyText.text = "Player 2 Money: " + player2Currency;

    }

}
