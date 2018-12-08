using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGMSource;
    public AudioSource SFXSource;
    public AudioClip[] clips;

    static public SoundManager instance_;

    private void Start()
    {
        if (instance_ == null)
            instance_ = this;
    }
    public void SFXPlay(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
