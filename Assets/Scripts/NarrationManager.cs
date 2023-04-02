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
    private float hideDelay = 2.5f;
    private bool isWriting;

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
        yield return ShowNotification("Salutations, noble vassal!");
        yield return ShowNotification("Vous avez pr�t� all�geance au roi le plus malin et le plus strat�gique de tout le royaume");
        yield return ShowNotification("Nous sommes en guerre contre notre rival pour le tr�ne");
        yield return ShowNotification("Et nous avons besoin de vous pour prot�ger notre territoire contre les attaques ennemies!");
        yield return ShowNotification("Construisez des tours de d�fense!");
        yield return ShowNotification("Organisez vos troupes!");
        yield return ShowNotification("Et soyez pr�t � tout moment!");
        yield return ShowNotification("Si vous survivez � toutes les vagues ennemies!");
        yield return ShowNotification("Vous serez g�n�reusement r�compens� pour votre loyaut�!");
        yield return ShowNotificationSec("Bonjour, vassal!");
        yield return ShowNotificationSec("Vous avez choisi de servir sous les ordres du roi le plus puissant et le plus cruel de tout le pays!");
        yield return ShowNotificationSec("Nous sommes en guerre contre notre ennemi jur� pour le contr�le du tr�ne!");
        yield return ShowNotificationSec("Et nous avons besoin de votre force pour d�fendre notre territoire contre les attaques ennemies!");
        yield return ShowNotificationSec("Construisez des tours de d�fense!");
        yield return ShowNotificationSec("Rassemblez vos troupes et pr�parez-vous pour la bataille!");
        yield return ShowNotificationSec("Si vous survivez � toutes les vagues ennemies!");
        yield return ShowNotificationSec("Vous serez r�compens� pour votre loyaut� envers notre roi et notre pays!");
    }
    private IEnumerator ShowNotification(string message)
    {
        notificationObject.SetActive(true);
        textMeshPro.text = message;
        isMessage = true;

        yield return new WaitForSeconds(hideDelay);

        HideNotification();
    }

    private IEnumerator ShowNotificationSec(string message)
    {
        notificationObjectSec.SetActive(true);
        textMeshProSec.text = message;
        isMessage = true;

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