using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }
    public AudioClip[] soundEffects;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeSound()
    {
        audioSource.volume.CompareTo(1.0f);
        audioSource.PlayOneShot(soundEffects[0]);
    }

    public void MatchSound()
    {
        audioSource.volume.CompareTo(0.1f);
        audioSource.PlayOneShot(soundEffects[1]);
    }


}
