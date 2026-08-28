using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class SoundManager : MonoBehaviour
{
    public AudioClip[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;


 

    public void PlayMusic(int id)
    {
        if (id < 0 || id >= musicSounds.Length)
        {
            return;
        }
        else
        {
            musicSource.clip = musicSounds[id];
            musicSource.Play();
        }
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void PlaySFX(int id)
    {
        if (id <0 || id >= sfxSounds.Length)
        {
            return;
        }
        else
        {
            sfxSource.clip = sfxSounds[id];
            sfxSource.Play();
        }
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }
}
