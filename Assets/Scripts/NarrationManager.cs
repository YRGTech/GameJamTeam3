using TMPro;
using UnityEngine;
using System.Collections;


public class NarrationManager : MonoBehaviour
{
    [SerializeField] GameObject notificationObject;
    [SerializeField] GameObject notificationObjectSec;
    private TextMeshProUGUI textMeshPro;
    private TextMeshProUGUI textMeshProSec;
    [SerializeField] string message;
    private bool isMessage;
    private float hideDelay = 1.5f;
    private bool isWriting;
    [SerializeField] float letterDelay;

    private void Awake()
    {
        notificationObject.SetActive(false);
        notificationObjectSec.SetActive(false);
    }

    public void Start()
    {
        textMeshPro = notificationObject.GetComponentInChildren<TextMeshProUGUI>();
        textMeshProSec = notificationObjectSec.GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(ShowNotifications());
    }

    private IEnumerator ShowNotifications()
    {
        yield return ShowNotification("Salutations, noble Vassal !");
        yield return ShowNotification("Vous avez prêté allégeance au Suzerain d'York.");
        yield return ShowNotification("le plus malin et le plus stratégique de tout le royaume.");
        yield return ShowNotification("Nous sommes en guerre contre notre rival, la Maison de Lancastre, pour le trône d'Angleterre.");
        yield return ShowNotification("Et nous avons besoin de vous pour protéger notre territoire de la province du Nord contre les attaques ennemies !");
        yield return ShowNotification("Construisez des tours de défense !");
        yield return ShowNotification("Organisez vos troupes !");
        yield return ShowNotification("Et soyez prêt à tout moment !");
        yield return ShowNotification("Si vous survivez à toutes les vagues ennemies.");
        yield return ShowNotification("Vous serez généreusement récompensé pour votre loyauté envers la Maison d'York.");
        yield return ShowNotificationSec("Bonjour, Vassal !");
        yield return ShowNotificationSec("Vous avez choisi de servir sous les ordres du roi le plus puissant et le plus cruel de tout le pays.");
        yield return ShowNotificationSec("Le roi Henry VI de la Maison de Lancastre.");
        yield return ShowNotificationSec("Nous sommes en guerre contre notre ennemi juré, la Maison d'York.");
        yield return ShowNotificationSec("Pour le contrôle du trône d'Angleterre.");
        yield return ShowNotificationSec("Et nous avons besoin de votre force pour défendre notre territoire de la province du Sud contre les attaques ennemies.");
        yield return ShowNotificationSec("Construisez des tours de défense !");
        yield return ShowNotificationSec("Rassemblez vos troupes et préparez-vous pour la bataille !");
        yield return ShowNotificationSec("Si vous survivez à toutes les vagues ennemies.");
        yield return ShowNotificationSec("Vous serez récompensé pour votre loyauté envers le roi Henry VI et la Maison de Lancastre !");

    }
    private IEnumerator ShowNotification(string message)
    {
        notificationObject.SetActive(true);
        textMeshPro.text = "";
        isMessage = true;

        for (int i = 0; i < message.Length; i++)
        {
            isWriting = true;
            textMeshPro.text += message[i];
            yield return new WaitForSeconds(letterDelay);
        }

        isWriting = false;

        yield return new WaitForSeconds(hideDelay);


        HideNotification();
    }

    private IEnumerator ShowNotificationSec(string message)
    {
        notificationObjectSec.SetActive(true);
        textMeshProSec.text = "";
        isMessage = true;

        for (int i = 0; i < message.Length; i++)
        {
            isWriting = true;
            textMeshProSec.text += message[i];
            yield return new WaitForSeconds(letterDelay);
        }

        isWriting = false;

        yield return new WaitForSeconds(hideDelay);


        HideNotificationSec();
    }

    private void HideNotification()
    {
        isMessage = false;
        notificationObject.SetActive(false);
    }
    private void HideNotificationSec()
    {
        isMessage = false;
        notificationObjectSec.SetActive(false);
    }
}