using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;
    public static int Money;
    public static int Rounds;

    [Header("Starting Values")]
    public int startLives = 20;
    public int startMoney = 400;

    void Start()
    {
        Lives = startLives;
        Money = startMoney;
        Rounds = 0;
    }
} 

