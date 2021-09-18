////Cathy Mengying Fang 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.Examples
{
    public class PostProcesserRetargeting : PostProcessProvider
    {

        [Header("Projection")]
        public Transform headTransform;


        public float maxWarp; //demo specific; unit [meter]
        public float warpRangeMin;
        public float warpRangeMax;
        private float retargeted_offset;
        
        public enum Demo { Uzi, Phone, Keypad, Button};
        public Demo demo;

        public SceneSwitcher sceneSwitcher;
        public bool isOffset;
        public bool isDynamic;

        public enum WarpHand { Left, Right }
        public WarpHand warpedHand = WarpHand.Left;
        //public GameObject attachObject;

        private bool CheckHand(Hand hand)
        {
            return ((warpedHand == WarpHand.Left && hand.IsLeft) || (warpedHand == WarpHand.Right && hand.IsRight));

        }
        
        public override void ProcessFrame(ref Frame inputFrame)
        {
            passthroughOnly = false;
            // Calculate the position of the head and the basis to calculate shoulder position.
            if (headTransform == null) { headTransform = Camera.main.transform; }
            Vector3 headPos = headTransform.position;

            isOffset = sceneSwitcher.offset;
            isDynamic = sceneSwitcher.dynamic;

            foreach (var hand in inputFrame.Hands)
            {
                if (CheckHand(hand) && isOffset) //check which hand is being retargeted
                {

                    //Warp Origin
                    Vector3 warpOrigin = hand.PalmPosition.ToVector3();

                    //Warp Direction
                    Vector3 palmZ = hand.PalmNormal.ToVector3();                  
                    Vector3 palmX = hand.PalmNormal.Cross(hand.Direction).Normalized.ToVector3();


                    // Warp Input
                    float dist = Mathf.Abs(headPos.x - warpOrigin.x);
                    float distZ = Mathf.Abs(headPos.z - warpOrigin.z);

                    if (demo.Equals(Demo.Phone))
                    {
                        maxWarp = 0.03f;
                        float warpInput = dist;
                        warpRangeMin = 0.05f;
                        warpRangeMax = 0.08f;
                        retargeted_offset = TransferFuncRising(warpInput, maxWarp, warpRangeMin, warpRangeMax);

                        warpOrigin -= retargeted_offset * palmZ;
                    }
                    
                    else if (demo.Equals(Demo.Uzi))
                    {
                        maxWarp = 0.07f;
                        float warpInput = dist;
                        warpRangeMin = 0.1f;
                        warpRangeMax = 0.17f;
                        retargeted_offset = TransferFuncRising(warpInput, maxWarp, warpRangeMin, warpRangeMax);
                       
                        warpOrigin += palmX * retargeted_offset;
                    }


                    else if (demo.Equals(Demo.Keypad))
                    {
                        maxWarp = 0.2f;
                        float warpInput = distZ;
                        warpRangeMin = 0.2f;
                        warpRangeMax = 0.4f;
                        retargeted_offset = TransferFuncFalling(warpInput, maxWarp, warpRangeMin, warpRangeMax);
                      
                        warpOrigin -= retargeted_offset * transform.right;
                    }


                    else if (demo.Equals(Demo.Button))
                    {
                        maxWarp = 0.2f;
                        float warpInput = distZ;
                        warpRangeMin = 0.2f;
                        warpRangeMax = 0.4f;
                        retargeted_offset = TransferFuncFalling(warpInput, maxWarp, warpRangeMin, warpRangeMax);

                        warpOrigin -= retargeted_offset * transform.right;
                    }

                    hand.SetTransform(warpOrigin, hand.Rotation.ToQuaternion());

                }


           
            }
        }

        private float TransferFuncRising(float warpInput, float maxWarp, float warpRangeMin, float warpRangeMax)
        {
            float offset;
            if (warpInput <= warpRangeMin) { offset = maxWarp; }
            else if (warpInput >= warpRangeMax) { offset = 0; }
            else { offset = warpRangeMax - warpInput; }
            return offset; 
        }
        private float TransferFuncFalling (float warpInput, float maxWarp, float warpRangeMin, float warpRangeMax)
        {
            float offset;
            if (warpInput > warpRangeMax) { offset = maxWarp; }
            else if (warpInput <= warpRangeMin) { offset = 0; }
            else { offset = warpInput - warpRangeMin; }
            return offset;
        }
    }
}
