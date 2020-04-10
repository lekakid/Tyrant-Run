using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] AudioClips;

    AudioSource _audioPlayer;
    Dictionary<string, AudioClip> _dic;

    void Awake()
    {
        _audioPlayer = GetComponent<AudioSource>();
        _dic = new Dictionary<string, AudioClip>();

        foreach(AudioClip audio in AudioClips) {
            _dic.Add(audio.name, audio);
        }
    }

    public void Play(string name) {
        _audioPlayer.PlayOneShot(_dic[name]);
    }
}
