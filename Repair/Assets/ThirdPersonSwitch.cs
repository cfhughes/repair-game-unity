using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonSwitch : MonoBehaviour
{
    public List<PressureGauge> pressureGauges;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        print("trigger enter!");
        if(c.gameObject.tag == "Player")
        {
            print("player enter!");
            foreach(PressureGauge pressureGuage in pressureGauges)
            {
                pressureGuage.Reset();
            }
        }
    }
}
