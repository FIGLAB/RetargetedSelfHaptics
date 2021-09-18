using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public bool offset = false;
    public bool dynamic = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        { 
            SceneManager.LoadScene("dynamic_phone"); 
        }
        else if (Input.GetKeyDown("u"))
        { 
            SceneManager.LoadScene("dynamic_uzi"); 
        }
        else if (Input.GetKeyDown("h"))
        { 
            SceneManager.LoadScene("dynamic_hammer");
        }
        else if (Input.GetKeyDown("k"))
        { 
            SceneManager.LoadScene("dynamic_keypad");
        }
        else if (Input.GetKeyDown("b"))
        { 
            SceneManager.LoadScene("dynamic_bigButton"); 
        }
        else if (Input.GetKeyDown("d"))
        {
            SceneManager.LoadScene("dynamic_door");
        }
        //else if (Input.GetKeyDown("w"))
        //{ 
        //    SceneManager.LoadScene("dynamic_whisk");
        //}
        else if (Input.GetKeyDown("r"))
        {
            offset = true;
            dynamic = true;
        }
        else if (Input.GetKeyDown("n"))
        {
            offset = false;
            dynamic = false;
        }
    }
}
