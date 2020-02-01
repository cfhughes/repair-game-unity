using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{

    public GameObject testObj;

    public Door door;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //print("space key was pressed");
            //testObj.SetActive(!testObj.activeInHierarchy);
            door.Toggle();
        }

        
    }
}
