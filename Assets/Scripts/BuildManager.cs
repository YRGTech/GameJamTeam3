using UnityEngine;

public class BuildManager : MonoBehaviour
{

    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a déja un BuildManager dans la scène !");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject standartTurretPrefab;


    private GameObject turretToBuild;


    private void Start()
    {
        turretToBuild = standartTurretPrefab;
    }



    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }


}
