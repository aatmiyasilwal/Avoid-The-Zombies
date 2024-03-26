using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChoose : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool playerbool = true;
    public static bool dragonbool = false;
    public static bool pokebool = false;
    string currentlvlstr;
    void Start()
    {
        currentlvlstr = SceneManager.GetActiveScene().name;
        if (int.Parse(currentlvlstr.Substring(5, 1)) > 1)
        {
            GameObject dragon = GameObject.Find("Dragon");
            GameObject player = GameObject.Find("Player");
            GameObject pokemon = GameObject.Find("PokeBall");
            player.SetActive(playerbool);
            dragon.SetActive(dragonbool);
            pokemon.SetActive(pokebool);
            
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (currentlvlstr == "CharS0")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //Select Stage
                    if (hit.transform.name == "Dragon")
                    {
                        devilchoose();

                    }
                    else if (hit.transform.name == "Player")
                    {
                        playerchoose();
                    }
                    else if (hit.transform.name == "PokeBall")
                    {
                        pokechoose();
                    }
                }
            }
        }
    }
    public void characterscene()
    {
        SceneManager.LoadScene("CharS0");
    }
    public void devilchoose()
    {
        dragonbool = true;
        pokebool = false;
        playerbool = false;
        if (SwitchScene.nosho)
        {
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            SceneManager.LoadScene("Scene1");
        }
    }
    public void pokechoose()
    {
        dragonbool = false;
        pokebool = true;
        playerbool = false;
        if (SwitchScene.nosho)
        {
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    public void playerchoose()
    {
        dragonbool = false;
        pokebool = false;
        playerbool = true;
        if (SwitchScene.nosho)
        {
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            SceneManager.LoadScene("Scene1");
        }
    }
    
}
