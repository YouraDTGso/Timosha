using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioObject : MonoBehaviour
{
    //public Music music;
    public Toggle musicTog;
    public AudioClip firstWorldMusic;
    public AudioClip SpaceWorldMusic;
    AudioSource CurrentSource;

    void Start()
    {
        CurrentSource = GetComponent<AudioSource>();
        CurrentSource.clip = firstWorldMusic;
        CurrentSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (musicTog.isOn==true)
        {
            GetComponent<AudioSource>().mute=false;
        }
        else if(musicTog.isOn == false)
        {
            GetComponent<AudioSource>().mute = true;
        }

        if (SpheresSpawn.scoreIs==30)
        {
            CurrentSource.clip = SpaceWorldMusic;
            CurrentSource.Play();
        }
        else if (SpheresSpawn.scoreIs == 60)
        {
            CurrentSource.clip = firstWorldMusic;
            CurrentSource.Play();
        }

    }
}
