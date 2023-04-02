using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int numPlayers = 2; // adjust this as needed
    public Tilemap[] walls; // the tilemaps that contain the walls
    public List<Tower> towers = new List<Tower>(); // an array of all the towers in the game

    public int[] towerOwners; // an array that maps each tower index to its owner ID

    public int turnPlayer;
    public TextMeshProUGUI playerTurnText;

    public static bool isOver;

    [SerializeField] GameObject imageRose;
    [SerializeField] GameObject imageBlanche;

    [SerializeField] Seigneur seigneurBlanche;
    [SerializeField] Seigneur seigneurRose;
    private void Start()
    {
        turnPlayer = 0;
    }

    public void Turn(int turn)
    {
        foreach (var tower in towers)
        {
            if (tower.ownerId == turn)
            {
                tower.GetComponent<TowerShoot>().enabled = true;
            }
            else
            {
                tower.GetComponent<TowerShoot>().enabled = false;

            }
        }
        foreach (var wall in walls)
        {
            int wallId = wall.GetComponent<WallController>().ownerId;
            if (wallId == turn)
            {
                wall.GetComponent<TilemapCollider2D>().enabled = true;
            }
            else
            {
                wall.GetComponent<TilemapCollider2D>().enabled = false;
            }
        }
    }
    public void NextTurn()
    {
        turnPlayer = (turnPlayer + 1) % numPlayers;
        foreach (var wall in walls)
        {
            wall.GetComponent<WallController>().resetHp();
        }

    }

    private void Update()
    {
        towerOwners = new int[towers.Count];
        for (int i = 0; i < towers.Count; i++)
        {
            towerOwners[i] = towers[i].ownerId;
        }
        Turn(turnPlayer);
        playerTurnText.text = "Player " + (turnPlayer + 1) + " turn's";

        if (isOver)
        {
            FindObjectOfType<SoundManager>().VictorySound();

            if (seigneurBlanche.Hp <= 0)
            {
                imageRose.SetActive(true);
            }
            else if (seigneurRose.Hp <= 0)
            {
                imageBlanche.SetActive(true);
            }
        }

    }

}