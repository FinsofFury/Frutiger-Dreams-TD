using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI waveText;

    void Update()
    {
        // update the stats continuously in the HUD
        moneyText.text = "$" + PlayerStats.Money.ToString();
        livesText.text = "LIVES: " + PlayerStats.Lives.ToString();
        waveText.text = "WAVE: " + PlayerStats.Rounds.ToString();
    }
}
