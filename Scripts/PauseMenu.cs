using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausepanel;
    static bool gamepausedbool = false;
    public GameObject pausebutton;
    // Start is called before the first frame update
    void Start()
    {
        gamepausedbool = false;
        pausepanel.SetActive(gamepausedbool);
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraController.fpsee)
        {
            if (Input.GetKey(KeyCode.Q)) //When looking a the map, the gigantic pauuse button hid some game objects, so the pasue button is disabled
            {
                pausebutton.SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                pausebutton.SetActive(true);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))//For the ease of the user
        {
            if (!gamepausedbool)
            { 
                gamepaused(); 
            }
            else
            {
                gameresume();
            }
            
        }
    }
    public void gamepaused() //For disabling time and showing the pane when the game is paused
    {
        CameraController.fpsee = false;
        gamepausedbool = true;
        pausepanel.SetActive(gamepausedbool);
        Time.timeScale = 0f;
    }
    public void gameresume()
    {
        CameraController.fpsee = true;
        gamepausedbool = false;
        pausepanel.SetActive(gamepausedbool);
        Time.timeScale = 1f;
    }
    //Pretty self-explanatory
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
