using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManger : MonoBehaviour
{
    public static bool PlayeEffect;
    private AudioSource auido;
    private void Start()
    {
        auido = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (PlayeEffect)
        {
            PlayeEffect = false;
            auido.Play();
        }
    }
}
