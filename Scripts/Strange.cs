using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    void Start()
    {
        Invoke("panelon", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void panelon()
    {
        panel.SetActive(false);
        CancelInvoke("panelon");
    }
}
