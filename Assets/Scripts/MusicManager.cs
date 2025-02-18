using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
