using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;
    public static int Money;

    [Header("Starting Values")]
    public int startLives = 20;
    public int startMoney = 400;

    void Start()
    {
        Lives = startLives;
        Money = startMoney;
    }
} 

