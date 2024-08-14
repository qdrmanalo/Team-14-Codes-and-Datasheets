using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicClips, sfxClips, voiceClips; // drag and add audio clips in the inspector
    public AudioSource musicSource, sfxSource, voiceSource;
    
    public void playMusic(int musicIndex) // the index of the sound, 0 for first sound, 1 for the 2nd..etc
    {
        if(musicSource.clip == null)
        {
            Debug.Log("Music Source Empty");
        }
        else
        {
            musicSource.clip = musicClips[musicIndex];
            musicSource.Play();
        }
    }

    public void playSFX(int sfxIndex)
    {
        if(sfxSource.clip == null)
        {
            Debug.Log("SFX Source Empty");
        }
        else
        {
            sfxSource.clip = sfxClips[sfxIndex];
            sfxSource.Play();
        }
    }

    public void playVoice(int voiceIndex)
    {
        if(voiceSource.clip == null)
        {
            Debug.Log("SFX Source Empty");
        }
        else
        {
            voiceSource.clip = voiceClips[voiceIndex];
            voiceSource.Play();
        }
    }
}