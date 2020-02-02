using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    public float overloadTotalTime;
    public float resetDelayMax;
    public ParticleSystem smoke;
    public GameObject sparks;
    public GameObject explosion;
    public List<AudioClip> explosionSounds;
    public AudioSource explosionAudioSource;
    public float overloadCurrentTime = 0;
    public float overloadPercent = 0;

    float minAngle = 0;
    float maxAngle = 60;
    float minEmission = 8;
    float maxEmission = 16;

    bool exploded = false;
    float overloadTotalTimeReset;


    GameController gameController;
    AudioSource audioSource;
    

    void Start()
    {
        overloadTotalTimeReset = overloadTotalTime;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        audioSource = GetComponent<AudioSource>();
        Reset();
    }

    void Update()
    {
        if(gameController.gameState == GameState.WAITING_FOR_START)
        {
            if(sparks.activeInHierarchy)
            {
                overloadTotalTime = overloadTotalTimeReset;
                Reset();
            }
            return;
        }

        overloadCurrentTime += Time.deltaTime;
        overloadPercent = Mathf.Min(overloadCurrentTime/overloadTotalTime, 1);
        var sh = smoke.shape;
        sh.angle = Mathf.Lerp(minAngle, maxAngle, overloadPercent);
        var em = smoke.emission;
        audioSource.volume = overloadPercent >= 1 ? 0 : overloadPercent;
        if(overloadPercent > .3 && !sparks.activeInHierarchy)
        {
            sparks.SetActive(true);
        }
        if(overloadPercent > .6)
        {
            em.rateOverTime = Mathf.Lerp(minEmission, maxEmission, overloadPercent);
        }
        if(overloadPercent >= 1 && ! exploded)
        {
            exploded = true;
            audioSource.volume = 0;
            explosionAudioSource.clip = explosionSounds[Random.Range(0, explosionSounds.Count - 1)];
            explosion.SetActive(false);
            explosion.SetActive(true);
            sparks.SetActive(false);
            em.rateOverTime = 0;
            gameController.EndGame();
        }
    }

    public void Reset()
    {
        overloadTotalTime *= .8f;
        exploded = false;
        sparks.SetActive(false);
        var em = smoke.emission;
        em.rateOverTime = 0;
        overloadCurrentTime = Random.Range(0, resetDelayMax) * -1;
    }
}
