using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{

    public GameObject testObj;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //print("space key was pressed");
            testObj.SetActive(!testObj.activeInHierarchy);
        }
    }
}
