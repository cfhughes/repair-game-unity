using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(isClosed);
    }

    public void Toggle()
    {
        isClosed = !isClosed;
        gameObject.SetActive(isClosed);
    }
}
