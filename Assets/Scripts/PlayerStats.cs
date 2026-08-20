using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;

    [Header("Starting Values")]
    public int startLives = 20;

    void Start()
    {
        Lives = startLives;
    }
} 

