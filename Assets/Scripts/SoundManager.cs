using UnityEngine;
using System.Collections;
using System;

public class SoundManager : MonoBehaviour
{
    public AudioSource background;
    public AudioSource snailSource;
    public AudioSource cannonFireSource;
    public AudioSource burnSource;
    public static SoundManager instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    //public AudioClip music1;
    //public AudioClip waves;

    public AudioClip cannonShotSound;

    public AudioClip startSnailSound;
    public AudioClip loopSnailSound;
    public AudioClip stopSnailSound;

    public AudioClip startFire1Sound;
    public AudioClip loopFire1Sound;
    public AudioClip stopFire1Sound;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    //////// base methods
    private void PlaySingle(AudioSource efxSource, AudioClip clip, bool isRandomPitch)
    {
        if (GameStateController.gameState == GameStateController.GameState.PLAYING)
        {
            if (isRandomPitch)
            {
                float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
                efxSource.pitch = randomPitch;
            }
            else efxSource.pitch = 1;

            efxSource.clip = clip;
            efxSource.Play();
        }
        else
        {
            efxSource.Pause();
        }
    }

    private void StopPlaying(AudioSource efxSource)
    {
        efxSource.Stop();
    }

    /////// game sound methods
    private double oldSpeed;
    internal void PlaySnailSound(double currentSpeed)
    {
        if (currentSpeed != 0)
        {
            if (oldSpeed == 0)
            {
                PlaySingle(snailSource, startSnailSound, false);
            }
            else if(!snailSource.isPlaying)
            {
                PlaySingle(snailSource, loopSnailSound, false);
            }
        }
        else if (oldSpeed != 0)
        {
            StopPlaying(snailSource);
            PlaySingle(snailSource, stopSnailSound, false);
        }
        oldSpeed = currentSpeed;
    }

    internal void CannonFire()
    {
        PlaySingle(cannonFireSource, cannonShotSound, false);
    }

    private double oldHealthProcent = 100;
    internal void BurnSound(double healthProcent)
    {
        if(healthProcent<20)
        {
            if (oldHealthProcent >= 20)
            {
                PlaySingle(burnSource, startFire1Sound, false);
            }
            else if (!burnSource.isPlaying)
            {
                PlaySingle(burnSource, loopFire1Sound, false);
            }
        }
        else if (oldHealthProcent < 20)
        {
            StopPlaying(burnSource);
            PlaySingle(burnSource, stopFire1Sound, false);
        }
        oldHealthProcent = healthProcent;
    }
}
