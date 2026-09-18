using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private Coroutine activeFade;
    private float maxMusicVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void FadeToNewTrack(AudioClip newClip, float fadeDuration = 1.5f)
    {
        if (activeFade != null) StopCoroutine(activeFade);
        activeFade = StartCoroutine(PerformFade(newClip, fadeDuration));
    }

    private IEnumerator PerformFade(AudioClip newClip, float duration)
    {
        float startVol = musicSource.volume;
        float halfDuration = duration / 2f;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVol * Time.deltaTime / halfDuration;
            yield return null;
        }

        musicSource.Stop();
        musicSource.clip = newClip;
        musicSource.Play();

        while (musicSource.volume < maxMusicVolume)
        {
            musicSource.volume += maxMusicVolume * Time.deltaTime / halfDuration;
            yield return null;
        }
    }
}
