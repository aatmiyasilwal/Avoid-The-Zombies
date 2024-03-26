using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool fpsee = true;
    GameObject player;
    public GameObject maincam, viewcam;
    string currentstrname;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    Vector3 offset;
    public float speedH = 2.0f;
    private float yaw = 0.0f;
    static bool dragonbool; 
    static bool playerbool;
    static bool pokebool;
    void Start()
    {
        
        currentstrname = SceneManager.GetActiveScene().name;
        //Setting the camera offsets so that the vew is looking JUICY
        if (currentstrname == "Scene5")
        {
            offset = new Vector3(1.2f, 2.0f, -11.4f);

        }
        else if (currentstrname == "Scene4")
        {
            offset = new Vector3(0f, 2.0f, -4.4f);

        }
        else if (currentstrname == "Scene3")
        {
            offset = new Vector3(0f, 2.0f, -2.0f);

        }
        else
        {
            offset = new Vector3(0.0f, 2.0f, -2.0f);

        }
        //For determining which character is to be followed
        dragonbool = CharacterChoose.dragonbool;
        playerbool = CharacterChoose.playerbool;
        pokebool = CharacterChoose.pokebool;
        if (playerbool)
            {
                player = player1;
            }
        else if(dragonbool)
            {
                player = player2;
            }
        else if (pokebool)
        {
            player = player3;
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        //For moving camera upon dragging the mouse 
        yaw += speedH * Input.GetAxis("Mouse X");
        if (fpsee)
        {
            if (maincam.activeInHierarchy)
            {
                if (Input.GetMouseButton(0))
                {

                    /*Quaternion rot = transform.rotation;
                    rot.x = 0.0f;
                    rot.z = 0.0f;
                    player.transform.rotation = rot;
                    */
                    maincam.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
                    if (currentstrname != "Scene5")
                    {
                        offset = new Vector3(0.0f, 1.3f, -3.7f);
                    }
                    else
                    {
                        offset = new Vector3(0.0f, 2.0f, -2.0f);
                    }


                }
                if (Input.GetMouseButtonUp(0))
                {
                    maincam.transform.eulerAngles = new Vector3(17.0f, 0.0f, 0.0f);
                    if (currentstrname == "Scene5")
                    {
                        offset = new Vector3(1.2f, 2.0f, -11.4f);

                    }
                    else
                    {
                        offset = new Vector3(0.0f, 2.0f, -2.6f);

                    }

                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                viewcam.SetActive(true);
                maincam.SetActive(false);
            }


            if (Input.GetKeyUp(KeyCode.Q))
            {
                viewcam.SetActive(false);
                maincam.SetActive(true);

            }
        }


    }
    private void LateUpdate()
    {
        maincam.transform.position = player.transform.position + offset;
    }
}
