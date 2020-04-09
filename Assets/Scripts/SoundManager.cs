using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource player;

    [SerializeField]
    public AudioClip[] clips;
    Dictionary<string, AudioClip> dic;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
        dic = new Dictionary<string, AudioClip>();

        foreach(AudioClip audio in clips) {
            dic.Add(audio.name, audio);
        }
    }

    public void Play(string name) {
        player.PlayOneShot(dic[name]);
    }
}
