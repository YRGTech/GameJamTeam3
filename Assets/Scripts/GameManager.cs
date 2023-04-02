using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public int numPlayers = 2; // adjust this as needed
    public Tilemap[] walls; // the tilemaps that contain the walls
    public List<Tower> towers = new List<Tower>(); // an array of all the towers in the game

    public int[] towerOwners; // an array that maps each tower index to its owner ID
    private Tilemap zone; // the tilemap that defines the zone where the towers are
    private void Start()
    {
       
    }

    private void Update()
    {
        towerOwners = new int[towers.Count];
        for (int i = 0; i < towers.Count; i++)
        {
            towerOwners[i] = towers[i].ownerId;
        }
    }

    private int ChangeTowerNewOwner( int currentOwner)
    {
        // TODO: Implement your own logic to determine the new owner of the tower
        // based on the location of the destroyed wall and the current owner.
        // For example, you could assign the tower to the player who destroyed the wall.
        return (currentOwner + 1) % numPlayers; // just an example
    }
}
