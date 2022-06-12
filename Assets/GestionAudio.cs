using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionAudio : MonoBehaviour
{

    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        if (PersistentManagerScript.Instance.muted)
        {
            audio.mute = !audio.mute;
        }
    }

    
}
