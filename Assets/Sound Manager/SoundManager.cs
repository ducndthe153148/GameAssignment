using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    public static SoundManager instance;
    void Awake()
    {
        //if (instance == null)
        //    instance = this;
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //DontDestroyOnLoad(this.gameObject); 
        foreach (Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        play("theme");    
    }
    // Update is called once per frame
    public void play(string nameSound)
    {
        Sound s= Array.Find(sounds, s => s.name == nameSound);
        if (s == null) Debug.Log("Sound "+nameSound+" not found") ;
        s.source.Play();
    }
}
