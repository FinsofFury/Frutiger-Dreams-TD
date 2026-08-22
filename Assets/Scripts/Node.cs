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
        if (GameManager.GameIsOver) return;

        if (currentTower != null) return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (GameManager.GameIsOver) return;

        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (GameManager.GameIsOver) return;

        if (currentTower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        if (PlayerStats.Money < BuildManager.instance.standardTowerCost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        
        PlayerStats.Money -= BuildManager.instance.standardTowerCost;

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();

        currentTower = Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
        Debug.Log("Tower built! Money left: " + PlayerStats.Money);
    }
}
