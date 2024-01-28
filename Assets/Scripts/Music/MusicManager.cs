using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance = null;

    public static MusicManager Instance => _instance;

    [SerializeField]
    List<AudioClip> _musics = new List<AudioClip>();

    AudioClip actualMusic;

    AudioSource audioSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ChooseAMusic();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            ChooseAMusic();
        }
    }

    void ChooseAMusic()
    {
        AudioClip musicToNotRePlay = null;
        if(actualMusic != null)
        {
            musicToNotRePlay = actualMusic;
        }
        actualMusic = _musics[Random.Range(0, _musics.Count)];
        _musics.Remove(actualMusic);
        if(musicToNotRePlay != null)
        {
            _musics.Add(musicToNotRePlay);
        }
        audioSource.clip = actualMusic;
        audioSource.Play();
    }
}
