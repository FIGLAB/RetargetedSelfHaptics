using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    //GameUI
    public GameObject reloadText;
    string reloadMsg;

   
    public Magazine magazine;
    public bool empty;

    public GameObject Mag;
    Animator animator;

    public AudioSource shootSound;

    private int numBullet = 5;

    // Start is called before the first frame update
    void Start()
    {
        animator = Mag.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "right" && magazine.inslot) //only respond to right index finger
        {           
            empty = false;
            numBullet--;
            reloadMsg = "Loaded! Ammo left: " + numBullet.ToString();
            reloadText.GetComponent<TMPro.TextMeshProUGUI>().text = reloadMsg;
            animator.SetTrigger("shoot");
            shootSound.Play();

            if (numBullet == 0)
            {
                empty = true;
                magazine.inslot = false;
                reloadMsg = "Push to reload";
                reloadText.GetComponent<TMPro.TextMeshProUGUI>().text = reloadMsg;
                Mag.transform.localPosition = new Vector3(-0.036f, 0, -0.009f); //magazine starting position
                numBullet = 5;
                
            }
        }
    }
}
