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
        canva.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !canva.activeSelf)
        {
            canva.SetActive(true);
            mainMenu.SetActive(true);
            optionMenu.SetActive(false);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && canva.activeSelf)
        {
            canva.SetActive(false);
            Time.timeScale = 1f;
        }

        if (!canva.activeSelf && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
}
