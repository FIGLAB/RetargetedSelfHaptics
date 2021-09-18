using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigButton : MonoBehaviour
{
    Animator animator;
    public bool collided;

    public GameObject Button;
    public AudioSource ButtonSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = Button.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "right")
        {
            ButtonSound.Play();
            Button.transform.localPosition = new Vector3(0, 0, 0.004f);
            collided = true;
            animator.SetTrigger("launch");
        }
        if (other.gameObject.tag == "left")
        {
            Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Button.transform.localPosition = new Vector3(0, 0, 0);
        collided = false;
        animator.ResetTrigger("launch");
    }
}
