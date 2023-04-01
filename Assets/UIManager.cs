using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject canva;
    public GameObject mainMenu;
    public GameObject optionMenu;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !canva.activeSelf)
        {
            canva.SetActive(true);
            mainMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && canva.activeSelf)
        {
            canva.SetActive(false);
            optionMenu.SetActive(false);
        }
    }
}
