using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{

    Rigidbody rb;
    Vector3 position;
    private float slotMaxLength = -0.012f;

    public bool inslot = false;
    public Trigger trigger;

    //GameUI
    public GameObject reloadText;
    string reloadMsg;

    public AudioSource loaded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        reloadMsg = "Push to reload";
        reloadMsg = reloadText.GetComponent<TMPro.TextMeshProUGUI>().text;
    }

    // Update is called once per frame
    void Update()
    {
        position = rb.transform.localPosition;
        if (position.x >= slotMaxLength) { position.x = slotMaxLength; } 
        rb.transform.localPosition = new Vector3(position.x, 0, -0.009f);
   
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Vector3 velocity = rb.velocity;
        Vector3 localVelocity = rb.transform.InverseTransformDirection(velocity);
        localVelocity.y = 0;
        localVelocity.z = 0;
        rb.velocity = transform.TransformDirection(localVelocity);

        position = rb.transform.localPosition;

        if (other.gameObject.tag != "right") //ignore right index finger
        {
            position.x += 0.012f;
            if (position.x >= slotMaxLength)
            {
                position.x = slotMaxLength;
                inslot = true;
                Debug.Log("inslot");

                loaded.Play(); //play sound
                //change UI
                reloadMsg = "Loaded!";
                reloadText.GetComponent<TMPro.TextMeshProUGUI>().text = reloadMsg;

            }

            rb.transform.localPosition = new Vector3(position.x, 0, -0.009f);
        }

    }

}
