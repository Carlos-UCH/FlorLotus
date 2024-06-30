using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    [Header("---- Music ----")]
    public AudioClip backgroundMusic;
    public AudioClip battleMusic;
    public AudioClip pauseMusic;

    // [Header("---- Music ----")]
    // public 

    private void Start()
    {
        this.music.clip = backgroundMusic;
        this.music.Play();
    }

    private void Update()
    {
        if (this.music.clip != pauseMusic && PauseMenu.gameIsPaused)
        {
            this.music.volume = 1;
            this.music.clip = pauseMusic;
            this.music.Play();
            return;
        }


        BattleManager battleManager = FindObjectOfType<BattleManager>();

        if (battleManager.IsInCombat() && this.music.clip == backgroundMusic)
        {
            this.music.volume = 1;
            this.music.clip = battleMusic;
            this.music.Play();
        }
        else if (battleManager.IsInCombat() && this.music.clip == battleMusic)
        {
            if (battleManager.GetBattleTimeLeft() > 0)
            {
                this.music.volume = battleManager.GetBattleTimeLeft() / BattleManager.AFTER_BATTLE_DELAY;
            }
        }
        else if (!battleManager.IsInCombat() && this.music.clip == battleMusic)
        {
            this.music.volume = 1;
            this.music.clip = backgroundMusic;
            this.music.Play();
        }
    }
}
