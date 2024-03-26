using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScript: MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Script for controls screen

    public void controls()
    {
        SceneManager.LoadScene("ControlsScene");
    }
    public void backhome()
    {
        SceneManager.LoadScene("Scene0");

    }

}
