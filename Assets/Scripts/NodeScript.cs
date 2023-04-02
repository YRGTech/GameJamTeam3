using UnityEngine;

public class NodeScript : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color startColor;
    private SpriteRenderer rend;
    public GameObject turret;


    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    private CurrencyManager currencyManager;
    public int playerId;

    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;
    }

    private void Update()
    {
        Tower tower = GetComponentInChildren<Tower>();
        if (tower != null)
        {
            playerId = tower.ownerId;

        }
    }

    private void OnMouseDown()
    {
        if (turret == null)
        {
            Button1.SetActive(!Button1.activeSelf);
            Button2.SetActive(!Button2.activeSelf);
            Button3.SetActive(!Button3.activeSelf);
        }

        if (turret != null || playerId != FindObjectOfType<GameManager>().turnPlayer)
        {
            Debug.Log("Impossible de construire ici, il y a déja une tourelle.");
        }
    }

    private void OnMouseEnter()
    {
        rend.material.color = new Color(1f, 1f, 1f, 0.7f);
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}





