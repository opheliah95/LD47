using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource playerAudio;
    public AudioSource enemyAudio;

    // sound delegates
    public delegate void OnSoundPlayDelegate(AudioClip clip);
    public static OnSoundPlayDelegate playPlayerSound;
    public static OnSoundPlayDelegate playEnemySound;

    private void OnEnable()
    {
        playPlayerSound += playerSound;
        playEnemySound += enemySound;
    }

    private void OnDisable()
    {
        playPlayerSound -= playerSound;
        playEnemySound -= enemySound;
    }

    public void playerSound(AudioClip clip)
    {
        playerAudio.clip = clip;
        playerAudio.Play();
        
    }

    public void enemySound(AudioClip clip)
    {
        enemyAudio.clip = clip;
        enemyAudio.Play();
    }
}
