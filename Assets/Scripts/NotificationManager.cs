using UnityEngine;
using TMPro;
using System.Collections;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] string message;
    [SerializeField] GameObject notificationObject;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        notificationObject = transform.GetChild(0).gameObject; 
        textMeshPro = notificationObject.GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void ShowNotification(string message)
    {
        Debug.Log("Marche");
        TextMeshProUGUI textMeshPro = notificationObject.GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = message;
        gameObject.SetActive(true);
        StartCoroutine(HideNotification(10.0f));
    }

    private IEnumerator HideNotification(float delay)
    {
        yield return new WaitForSeconds(delay);
        TextMeshProUGUI textMeshPro = notificationObject.GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = "";
        gameObject.SetActive(false);
    }
}
