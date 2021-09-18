using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.Earth
{
    public class EarthRootScript : MonoBehaviour
    {
        public float speed = 10f;

        public void Update()
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
        }
    }
}
