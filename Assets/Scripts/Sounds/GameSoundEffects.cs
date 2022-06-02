using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundEffects : MonoBehaviour
{
    public AudioSource source;

    public void PlayDrawSound()
    {
        source.Play();
    }
}
