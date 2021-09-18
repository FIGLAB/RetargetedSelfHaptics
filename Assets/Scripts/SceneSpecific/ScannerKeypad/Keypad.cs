
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{

    Animator animator;
   

    public bool scanned;
    public AudioSource confirmed;

    public Material scanner_mat_idle;
    public Material scanner_mat_green;
    public GameObject Scanner;
    
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
    private void OnTriggerEnter(Collider other)
    {
        confirmed.Play();
        animator.SetTrigger("open");
        scanned = true;
        Scanner.GetComponent<MeshRenderer>().material = scanner_mat_green;


    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetTrigger("closed");
        scanned = false;
        Scanner.GetComponent<MeshRenderer>().material = scanner_mat_idle;
        
    }
}
