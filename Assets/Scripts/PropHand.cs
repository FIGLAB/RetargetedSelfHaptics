using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropHand : MonoBehaviour
{
    public GameObject Prop;
    public GameObject GhostHand; //Traslucent hand that indicates expected Gesture and Position
    public GameObject ProppedHand; //Hand that is repurposed as a prop
    
    public Material hand_mat_translucent;
    public Material hand_mat_idle;
    public Material hand_mat_invisible;
    public Material hand_mat_green;

    public BigButton button;

    private bool collided;


    // Start is called before the first frame update
    void Start()
    {
       GhostHand.SetActive(true);
       Prop.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (collided) // propped hand in the right position
        {
            if (button.collided)
            {
                ProppedHand.GetComponent<SkinnedMeshRenderer>().material = hand_mat_invisible;
            }
            else
            {
                ProppedHand.GetComponent<SkinnedMeshRenderer>().material = hand_mat_translucent;
            }
        }
        else {
            ProppedHand.GetComponent<SkinnedMeshRenderer>().material = hand_mat_idle;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
        Prop.SetActive(true);
        GhostHand.GetComponent<MeshRenderer>().material = hand_mat_green;
        
    }

    private void OnTriggerExit(Collider other)
    {

        collided = false;
        Prop.SetActive(false);
        GhostHand.GetComponent<MeshRenderer>().material = hand_mat_translucent;
           

    }
}
