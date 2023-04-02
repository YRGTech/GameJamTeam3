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
        yield return ShowNotification("Vous avez pr�t� all�geance au Suzerain d'York.");
        yield return ShowNotification("le plus malin et le plus strat�gique de tout le royaume.");
        yield return ShowNotification("Nous sommes en guerre contre notre rival, la Maison de Lancastre, pour le tr�ne d'Angleterre.");
        yield return ShowNotification("Et nous avons besoin de vous pour prot�ger notre territoire de la province du Nord contre les attaques ennemies !");
        yield return ShowNotification("Construisez des tours de d�fense !");
        yield return ShowNotification("Organisez vos troupes !");
        yield return ShowNotification("Et soyez pr�t � tout moment !");
        yield return ShowNotification("Si vous survivez � toutes les vagues ennemies.");
        yield return ShowNotification("Vous serez g�n�reusement r�compens� pour votre loyaut� envers la Maison d'York.");
        yield return ShowNotificationSec("Bonjour, Vassal !");
        yield return ShowNotificationSec("Vous avez choisi de servir sous les ordres du roi le plus puissant et le plus cruel de tout le pays.");
        yield return ShowNotificationSec("Le roi Henry VI de la Maison de Lancastre.");
        yield return ShowNotificationSec("Nous sommes en guerre contre notre ennemi jur�, la Maison d'York.");
        yield return ShowNotificationSec("Pour le contr�le du tr�ne d'Angleterre.");
        yield return ShowNotificationSec("Et nous avons besoin de votre force pour d�fendre notre territoire de la province du Sud contre les attaques ennemies.");
        yield return ShowNotificationSec("Construisez des tours de d�fense !");
        yield return ShowNotificationSec("Rassemblez vos troupes et pr�parez-vous pour la bataille !");
        yield return ShowNotificationSec("Si vous survivez � toutes les vagues ennemies.");
        yield return ShowNotificationSec("Vous serez r�compens� pour votre loyaut� envers le roi Henry VI et la Maison de Lancastre !");

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