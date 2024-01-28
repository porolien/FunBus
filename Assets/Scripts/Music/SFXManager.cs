using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private static SFXManager _instance = null;

    public static SFXManager Instance => _instance;

    public GameObject SFXExemple;

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

    public void NewSFXPlay(AudioClip sfx)
    {
        GameObject newSFX = Instantiate(SFXExemple);
        newSFX.GetComponent<AudioSource>().clip = sfx;
        newSFX.GetComponent<AudioSource>().Play();
        StartCoroutine(DestroySFX(sfx.length, newSFX));
    }

    IEnumerator DestroySFX(float delay, GameObject sfxToDestroy)
    {
        yield return new WaitForSeconds(delay);
        Destroy(sfxToDestroy);
    }

}
