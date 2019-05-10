using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour {

    public AudioClip _loupDeath;
    public AudioClip _gameOver;
    public AudioClip _victory;
    public AudioClip _tire;
    public AudioClip _transi1;
    public AudioClip _transi2;
    public AudioClip _click;
    public AudioClip _jobdone;
    public AudioClip _hit;
    public AudioClip _music;
    public static SoundControler _soundControler;

    private AudioSource _source;

    private void Awake()
    {
        if (_soundControler == null)
            _soundControler = this;
        else
            Destroy(_soundControler.gameObject);

        _source = GetComponent<AudioSource>();
        
        _source.clip = _music;
        _source.loop = true;
        _source.Play();
    }

    public void PlaySound(AudioClip sound)
    {
        _source.PlayOneShot(sound);
    }

}
