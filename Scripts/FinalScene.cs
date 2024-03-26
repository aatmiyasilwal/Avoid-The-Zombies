using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    //public GameObject text;
    // Start is called before the first frame update
    /*GameObject dragon;
    
    float x = 0;
    float y = 0;
    float z = 0;
    */
    void Start()
    {
        //text.SetActive(true);
        /*dragon = GameObject.Find("Dragon");
        GameObject.Find("Dragon").GetComponent<Animator>().SetBool("DevilMove", false);
        */
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
         
         /*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y = 90;
            dragon.transform.Rotate(x,y,z,Space.Self);

        }
        currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;
        dragon.transform.eulerAngles = currentEulerAngles;
        
        if (Input.GetKey(KeyCode.DownArrow))
        {

            GameObject.Find("Dragon").GetComponent<Animator>().SetBool("DevilMove", true);
            Vector3 playerposition = new Vector3(0.0f, 0.0f, 0.0f);
            playerposition.z = -0.05f;
            dragon.transform.position += playerposition;
            //devil.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(-Vector3.back);


        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            
            GameObject.Find("Dragon").GetComponent<Animator>().SetBool("DevilMove", false);
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y = -90;
            dragon.transform.Rotate(x, y, z, Space.Self);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            GameObject.Find("Dragon").GetComponent<Animator>().SetBool("DevilMove", true);
            Vector3 playerposition = new Vector3(0.0f, 0.0f, 0.0f);
            playerposition.z = 0.05f;
            dragon.transform.position += playerposition;
            //dragon.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(-Vector3.forward);

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GameObject.Find("Drafon").GetComponent<Animator>().SetBool("DevilMove", false);

        }
        */
    }
    //Final scene only controller
    public void gohome()
    {
        PlayerController.score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene0");
    }
    public void gameexit()
    {
        PlayerController.score = 0;
        Time.timeScale = 1f;
        Application.Quit();
    }




}
