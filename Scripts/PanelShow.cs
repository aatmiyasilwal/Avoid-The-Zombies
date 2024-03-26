using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelShow : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        //For the scene where player's name is asked
        if (SwitchScene.playernamebool || PlayerController.playername == "")
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
