using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Leap;
using Leap.Unity.Attributes;
using UnityEngine.Serialization;

namespace Leap.Unity
{
    public class RiggedHandExtension : RiggedHand
    {
        public bool[] fingersEnabled = new bool[] { true, true, true, true, true };
        public override void UpdateHand()
        {
            
            for (int i = 0; i < fingers.Length; ++i)
            {

                if (fingers[i] != null && fingersEnabled[i])
                {
                    fingers[i].fingerType = (Finger.FingerType)i;
                    fingers[i].UpdateFinger();
                }
            }
        }

    }
}