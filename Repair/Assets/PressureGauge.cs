using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    public float overloadTotalTime;
    public float resetDelayMax;
    public ParticleSystem smoke;
    public GameObject sparks;

    float overloadCurrentTime = 0;
    float minAngle = 0;
    float maxAngle = 60;
    float minEmission = 8;
    float maxEmission = 16;


    GameController gameController;
    

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Reset();
    }

    void Update()
    {
        if(gameController.gameState == GameState.WAITING_FOR_START)
        {
            return;
        }

        overloadCurrentTime += Time.deltaTime;
        float overloadPercent = Mathf.Min(overloadCurrentTime/overloadTotalTime, 1);
        var sh = smoke.shape;
        sh.angle = Mathf.Lerp(minAngle, maxAngle, overloadPercent);
        var em = smoke.emission;
        if(overloadPercent > .3 && !sparks.activeInHierarchy)
        {
            sparks.SetActive(true);
        }
        if(overloadPercent > .6)
        {
            em.rateOverTime = Mathf.Lerp(minEmission, maxEmission, overloadPercent);
        }
        if(overloadPercent >= 1)
        {
            gameController.EndGame();
        }
    }

    public void Reset()
    {
        sparks.SetActive(false);
        var em = smoke.emission;
        em.rateOverTime = 0;
        overloadCurrentTime = Random.Range(0, resetDelayMax) * -1;
    }
}
