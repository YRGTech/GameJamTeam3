using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vassal : MonoBehaviour
{
    public int pv = 1000;

    private void Update()
    {
        if (pv <= 0) Debug.Log("Game Over");
    }
}
