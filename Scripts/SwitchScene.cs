using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject next;
    public static bool nosho = false;
    public static bool playernamebool = true;
    public static bool audiobool = true;
    string currentlvlstr;
    static int nextlvlint = 1;
    public GameObject audios;
    // Start is called before the first frame update
    
    void Start()
    {
        
        currentlvlstr =  SceneManager.GetActiveScene().name; 
        nextlvlint = int.Parse(currentlvlstr.Substring(5,1)) + 1; //Sorted the levels out in such a way that extracting the last character would help out with the scene switching
       if (currentlvlstr != "Scene0")
        
        {   
            audios.SetActive(audiobool);
        }
    }

   
    // Update is called once per frame
    void Update()
    {
            
        if (currentlvlstr == "Scene1")
        {
            
            if (playernamebool)
            {
                if (Input.GetKey(KeyCode.Return)) //For the ease of the user (not having to use the mouse)
                {
                    nameforplayer();
                }
            }
            else if (!playernamebool)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    nextlvl();
                }
            }
            
        }
        else if (currentlvlstr == "Stats0")
        {
            if (Input.GetKey(KeyCode.Return)) //For getting from the controls screen or the stats screen to the home
            {
                SceneManager.LoadScene("Scene0");
            }
        }
        if (currentlvlstr != "CharS0" && int.Parse(currentlvlstr.Substring(5, 1)) >= 2)
        {
            if (PlayerController.enterenabledback)  //For the ease of the user (not having to use the mouse)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    playagain();
                }
            }
            else if (PlayerController.enterenablednext)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    nextlvl();
                }
            }
        }

    }
    public void nomo() //Upn enabling "Don't show the rules again"
    {

        nosho = true;
        nextlvl();

    }
    public void nextlvl() //Fuction that helps getting to the next level 
    {
        next.SetActive(true);
        string nxtlvl = nextlvlint.ToString();
        if (currentlvlstr == "Scene0" && nosho == true)
        {
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            SceneManager.LoadScene("Scene" + nxtlvl);

        }
        nextlvlint++;
    }
    public void stats() //Enabled upon clicking the stats button
    {
        SceneManager.LoadScene("Stats0");
    }
    public void control()
    {
        SceneManager.LoadScene("ContS0"); //Enabled upon clicking the controls button
    }
    public void playagain()
    {
        //nextlvlint = 3;
        if (!nosho) //Checking if "Don't show this again" is enabled or not
        { 
            SceneManager.LoadScene("Scene1");
        }
        else
        {
            SceneManager.LoadScene("Scene2");

        }
    }
    public void enableaudio()
    {
        //Extremely fussy code but gets the job done when it come to enabling or disabling audio
        GameObject.Find("Audios").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Audios").GetComponent<BGSoundScript>().enabled = true;
        audiobool = true;
        

    }
    public void disableaudio()
    {
        GameObject.Find("Audios").GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Audios").GetComponent<BGSoundScript>().enabled = false;
        audiobool = false;
        

    }

    public void clearstats() //Resetting the game stats
    {
        PlayerPrefs.DeleteAll();
    }
    public void nameforplayer() 
    {
        playernamebool = false;
        PlayerController.playername = GameObject.Find("PlayerName").GetComponent<Text>().text;
        nextlvl();
    }      
    public void gohome()
    {
        SceneManager.LoadScene("Scene0");
    }
}


