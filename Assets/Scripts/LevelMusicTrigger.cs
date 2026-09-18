using UnityEngine;

public class LevelMusicTrigger : MonoBehaviour
{
    [Header("Level Audio")]
    [Tooltip("The music track that should play during this specific level.")]
    public AudioClip levelTrack;

    [Tooltip("How long the crossfade should take in seconds.")]
    public float fadeTime = 2.0f;

    private void Start()
    {
        if (AudioManager.Instance != null && levelTrack != null)
        {
            AudioManager.Instance.FadeToNewTrack(levelTrack, fadeTime);
        }
        else
        {
            Debug.LogWarning("AudioManager instance is missing, or no level track was assigned!");
        }
    }
}
