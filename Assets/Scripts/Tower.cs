using UnityEngine;

public class Tower : MonoBehaviour
{
    public int ownerId; // the ID of the player who owns the tower

    private void OnEnable() => FindObjectOfType<GameManager>().towers.Add(this);
    private void OnDisable() => FindObjectOfType<GameManager>().towers.Remove(this);
}
