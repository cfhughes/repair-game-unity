using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    public float overloadTotalTime;
    public ParticleSystem smoke;

    float overloadCurrentTime = 0;
    float minAngle = 0;
    float maxAngle = 60;
    float minEmission = 8;
    float maxEmission = 16;


    void Update()
    {
        overloadCurrentTime += Time.deltaTime;
        float overloadPercent = Mathf.Min(overloadCurrentTime/overloadTotalTime, 1);
        var sh = smoke.shape;
        sh.angle = Mathf.Lerp(minAngle, maxAngle, overloadPercent);
        var em = smoke.emission;
        if(overloadPercent < .3)
        {
            em.rateOverTime = 0;
        }
        else
        {
            em.rateOverTime = Mathf.Lerp(minEmission, maxEmission, overloadPercent);
        }
    }

    public void Reset()
    {
        overloadCurrentTime = 0;
    }
}
