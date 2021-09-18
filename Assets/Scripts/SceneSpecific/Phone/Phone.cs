using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private float posX;
    private float posZ;

    public Material button_mat_idle;
    public Material button_mat_tap;

    public AudioSource beep;
    // Start is called before the first frame update
    void Start()
    {
        posX = this.transform.localPosition.x;
        posZ = this.transform.localPosition.z;
        this.GetComponent<MeshRenderer>().material = button_mat_idle;

    }

    // Update is called once per frame
    void Update()
    {
        if (posX <= -0.01f) { posX = -0.01f; }
        else if (posX >= 0.01f) { posX = 0.01f; }

        if (posZ <= -0.01f) { posZ = -0.01f; }
        else if (posZ >= 0.01f) { posZ = 0.01f; }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "right") {
            beep.Play();


            posX = Random.Range(-0.01f, 0.01f);
            if (posX <= -0.01f) { posX = -0.01f; }
            else if (posX >= 0.01f) { posX = 0.01f; }
            posZ = Random.Range(-0.01f, 0.02f);
            if (posZ <= -0.01f) { posZ = -0.01f; }
            else if (posZ >= 0.01f) { posZ = 0.01f; }

            this.GetComponent<MeshRenderer>().material = button_mat_tap;
            Invoke("delayedAction", 0.4f);
        }
    }
    
    private void delayedAction()
    {
        this.transform.localPosition = new Vector3(posX, 0.006f, posZ);
        this.GetComponent<MeshRenderer>().material = button_mat_idle;
    }
}
