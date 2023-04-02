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
        player++;
        if (player == 1)
        {
            player1Currency += amount;
        }
        else if (player == 2)
        {
            player2Currency += amount;
        }
    }

    public int CheckCurrency(int player)
    {
        player++;
        if (player == 1)
        {
            return player1Currency;
        }
        else if (player == 2)
        {
            return player2Currency;
        }
        else return 0;
    }

    private void Update()
    {
        player1MoneyText.text = "Player 1 Money: " + player1Currency;
        player2MoneyText.text = "Player 2 Money: " + player2Currency;

    }

}
