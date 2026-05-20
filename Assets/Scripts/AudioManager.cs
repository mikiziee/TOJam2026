using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource2D;
    [SerializeField] AudioSource SFXSource3D;

    public AudioClip buttonClick; 
    public AudioClip buttonClickReturn; 
    public AudioClip buttonFinished;
    public AudioClip grab;
    public AudioClip placeDecline;
    public AudioClip gainPoints;
    public AudioClip dropItem;
    //public AudioClip engineIdle;
    //public AudioClip distantWolves;
    //public AudioClip childCrying;
    //public AudioClip spookyAmbience;

    public void Play2DSFX(AudioClip clip)
    {
        SFXSource2D.PlayOneShot(clip);
    }
}
