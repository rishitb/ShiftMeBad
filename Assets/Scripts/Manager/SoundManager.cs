/// <summary>
/// This Sound Manager script handles all the sound related functionality.
/// The script is attached to an empty gameobject and listens to the attached Audio Source
/// </summary>
using UnityEngine;
using System.Collections;


public class SoundManager : MonoBehaviour{

	public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource mfxSource;       			//Plays the music
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
   

    void Awake()
    {
		if (SoundManager.instance == null) {
			SoundManager.instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
    }


    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.            
        efxSource.clip = clip;            
        //Play the clip.
        efxSource.Play();
    }

    //Used to play single sound clips.
    public void PlayMusic(AudioClip clip)
    {
        //Set the clip of our mfxSource audio source to the clip passed in as a parameter.
        mfxSource.clip = clip;
        //Play the clip.
        mfxSource.Play();
    }

    public AudioSource getCurrentMusic()
    {
        return mfxSource;
    }

    public void stopMusic(AudioSource clip)
    {
        clip.Stop();
    }

    public void MuteAll()
    {
        AudioSource[] src = this.GetComponents<AudioSource>();
        foreach (AudioSource s in src) {
            s.volume = 0;
        }
    }

    public void UnMuteAll()
    {
        AudioSource[] src = this.GetComponents<AudioSource>();
        foreach (AudioSource s in src)
        {
            s.volume = 0.35f;           
        }
    }
}
