using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonSoundPlayer : MonoBehaviour
{
    public AudioClip onSelect;

    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayOnSelect()
    {
        StartCoroutine(PlayClip(onSelect));
    }
    
    IEnumerator PlayClip(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
    }
}
