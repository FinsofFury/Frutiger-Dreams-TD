using UnityEngine;

public class GameManager : MonoBehaviour
{
    // gameover flag
    public static bool GameIsOver = false;

    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver) return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        Debug.Log("GAME OVER!");

        // freeze all the things
        Time.timeScale = 0f; 
    }
}
