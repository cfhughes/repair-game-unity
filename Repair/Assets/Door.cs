using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Animator animator;
    AudioSource audioSource;
    public bool isClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //gameObject.SetActive(isClosed);
    }

    public void Toggle()
    {
        isClosed = !isClosed;
        animator.Play(isClosed ? "DoorCloseAnimation" : "DoorOpenAnimation");
        audioSource.Play();
        //gameObject.SetActive(isClosed);
    }
}
