using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }
    public GameObject[] particleEffects;
    public AudioClip[] soundEffects;
    private AudioSource audioSource;
    private Transform effectTransform;

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

    public void MatchEffect(int gridNum)
    {
        effectTransform = GridManager.Instance.Ducks[gridNum].transform;
        Instantiate(particleEffects[0], effectTransform.position, effectTransform.rotation);
    }

}
