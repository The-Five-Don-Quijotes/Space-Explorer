using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    private AudioSource themeMusic;

    void Start()
    {
        themeMusic = GetComponent<AudioSource>();
        Invoke("PlayMusic", 2f); // Delays music by 3 seconds
    }

    void PlayMusic()
    {
        themeMusic.Play();
    }
}
