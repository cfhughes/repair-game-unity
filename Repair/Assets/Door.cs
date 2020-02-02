using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Animator animator;
    public bool isClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //gameObject.SetActive(isClosed);
    }

    public void Toggle()
    {
        isClosed = !isClosed;
        animator.Play(isClosed ? "DoorCloseAnimation" : "DoorOpenAnimation");
        //gameObject.SetActive(isClosed);
    }
}
