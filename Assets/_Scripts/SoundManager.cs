using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    //KNN the stupid plug in reserved the term "Audio Manager" so i LLST have to call it SoundManager fucking L
    [Header("These are the various Audio Sources")]
    [SerializeField] private GameObject BGMSource;

    [Header("List of all the fuck shit audio sources for all the fuck shit sounds")]
    [SerializeField] private AudioSource[] MiscAudioSources;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip ac)
    {
        foreach(AudioSource AS in MiscAudioSources){
            if(AS.isPlaying){
                break;
            }
            else{
                AS.clip = ac;
                AS.Play();
            }
        }
    }
}
