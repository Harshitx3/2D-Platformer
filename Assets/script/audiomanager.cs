using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [SerializeField] AudioSource musicsource;
    [SerializeField] AudioSource sfx;

    [Header("________________Clip_________")]

    public AudioClip bg;
    public AudioClip death;
    public AudioClip checkpoint;
    public AudioClip inportal;
    public AudioClip outportal;
    public AudioClip wall;



    private void Start()
    {
        musicsource.clip = bg;
        musicsource.Play();



    }


    public void PlaySpx(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }



}
