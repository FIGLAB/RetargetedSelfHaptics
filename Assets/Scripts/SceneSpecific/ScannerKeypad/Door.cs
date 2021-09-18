using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private int password = 0;
    Animator animator;
    private bool isOpen = false;

    public Keypad keypad;

    public AudioSource tap;
    
    // Start is called before the first frame update
    void Start()
    {
        //animator = doorParent.GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "right" && keypad.scanned)
        {
            password++;
            tap.Play();

            Debug.Log("password:" + password);
            if (password == 3)
            {

                animator.SetTrigger("doorOpen");
                Debug.Log("open door");
                isOpen = true;
                password = 0;
                Invoke("closeDoor", 3);
            }
        }
    }
   
    private void closeDoor()
    {
        animator.SetTrigger("doorClose");
        isOpen = false;
       
    }
}
