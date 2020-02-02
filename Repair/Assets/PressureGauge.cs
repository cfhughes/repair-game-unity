﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    public float overloadTotalTime;
    public ParticleSystem smoke;
    public GameObject sparks;

    float overloadCurrentTime = 0;
    float minAngle = 0;
    float maxAngle = 60;
    float minEmission = 8;
    float maxEmission = 16;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        overloadCurrentTime += Time.deltaTime;
        float overloadPercent = Mathf.Min(overloadCurrentTime/overloadTotalTime, 1);
        var sh = smoke.shape;
        sh.angle = Mathf.Lerp(minAngle, maxAngle, overloadPercent);
        var em = smoke.emission;
        if(overloadPercent > .3 && !sparks.activeInHierarchy)
        {
            sparks.SetActive(true);
        }
        else if(overloadPercent > .6)
        {
            em.rateOverTime = Mathf.Lerp(minEmission, maxEmission, overloadPercent);
        }
    }

    public void Reset()
    {
        print(sparks.transform.position.y);
        sparks.SetActive(false);
        var em = smoke.emission;
        em.rateOverTime = 0;
        overloadCurrentTime = 0;
    }
}
