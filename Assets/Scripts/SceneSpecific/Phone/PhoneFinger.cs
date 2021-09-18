using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using Leap.Unity;

public class PhoneFinger : MonoBehaviour
{
    public GameObject PokeHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "palm")
        {
            PokeHand.GetComponent<RiggedHandExtension>().fingersEnabled[1] = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "palm")
        {
            PokeHand.GetComponent<RiggedHandExtension>().fingersEnabled[1] = true;
        }
    }
}
