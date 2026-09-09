using System.Collections;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [Header("Material Swap Settings")]
    public MeshRenderer endpointRenderer;
    public Material defaultMaterial;
    public Material damageMaterial;
    public float flashDuration = 0.2f;

    public void TakeDamage()
    {
        PlayerStats.Lives--;

        if (endpointRenderer != null)
        {
            StartCoroutine(FlashDamage());
        }

    }

    private IEnumerator FlashDamage()
    {
        endpointRenderer.material = damageMaterial;

        yield return new WaitForSecondsRealtime(flashDuration);

        endpointRenderer.material = defaultMaterial;
    }

}
