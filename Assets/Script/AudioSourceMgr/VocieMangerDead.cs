using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VocieMangerDead : MonoBehaviour
{
    private static AudioSource DeadVoice;
    private void Start()
    {
        DeadVoice = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
    }
    public static void DeadEffect()
    {
        DeadVoice.Play();
    }
}
