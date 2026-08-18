using UnityEngine;

public class Node : MonoBehaviour
{
    [Header("Hover Colors")]
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;

    [Header("Building Setup")]
    public Vector3 positionOffset; // so the tower doesnt go into the tile

    private GameObject currentTower;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        if (currentTower != null) return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (currentTower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();

        currentTower = Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }
}
