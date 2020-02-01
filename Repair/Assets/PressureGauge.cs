using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    public float overloadTotalTime;

    float overloadCurrentTime = 0;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        overloadCurrentTime += Time.deltaTime;
        float overloadPercent = Mathf.Min(overloadCurrentTime/overloadTotalTime, 1);
        animator.Play("PressureGaugeAnim", 0, overloadPercent);
    }

    public void Reset()
    {
        overloadCurrentTime = 0;
    }
}
