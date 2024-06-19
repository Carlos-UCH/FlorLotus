using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    [Header("---- Music ----")]
    public AudioClip backgroundMusic;
    public AudioClip battleMusic;
    public bool isBattling = false;

    // [Header("---- Music ----")]
    // public 

    private void Start() {
        this.music.clip = backgroundMusic;
        this.music.Play();
    }

    public bool IsInBattle() {
        return this.isBattling;
    }

    public void ToggleBattleMusic() {
        this.isBattling = this.isBattling ? false : true;

        if (this.isBattling && this.music.clip == backgroundMusic)
        {
            this.music.clip = battleMusic;
            this.music.Play();
            return;
        }

        this.music.clip = backgroundMusic;
        this.music.Play();
    }
}
