using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // using singleton for easier access
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    [Header("Prefabs")]
    public GameObject standardTowerPrefab;

    public GameObject GetTowerToBuild()
    {
        return standardTowerPrefab;
    }
}