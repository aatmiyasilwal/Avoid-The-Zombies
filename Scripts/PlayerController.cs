using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //bool gamepaused = false;
    public Rigidbody rb1, rb2, rb3;
    Rigidbody rb;
    Vector3 abc;
    float timervar;
    public static float ms, seconds, minutes;
    int statuenum ;
    bool timerstop;
    float speed = 19f;
    public GameObject next;
    public Text stopwatchtext;
    public Text txtScore;
    public Text endtxt;
    public ParticleSystem pSplayer;
    public GameObject panel1;
    public Text txt2;
    GameObject player;
    public GameObject player1;
    public GameObject player2, player3;
    bool outofBounds;
    public GameObject panelB;
    public static int score, currenths;
    bool isGameover;
    int possibleHigh;
    float timetaken1, timetaken2, timetaken3,timetaken4;
    public Text nexttxt;
    public AudioSource coinaudio, gameoveraudio, wallhitaudio, nextlevelaudio;
    public GameObject spotlight, spotlight2;
    Vector3 spotlightoffset;
    public static bool enterenabledback, enterenablednext;
    static string playerhigh;
    public static string playername;


    void Start()
    {
        CameraController.fpsee = true;
        timerstop = false;
        currenths = PlayerPrefs.GetInt("HighScore",0);
        timetaken1 = PlayerPrefs.GetFloat("Lvl1T", 5999f);
        timetaken2 = PlayerPrefs.GetFloat("Lvl2T", 5999f);
        timetaken3 = PlayerPrefs.GetFloat("Lvl3T", 5999);
        timetaken4 = PlayerPrefs.GetFloat("Lvl4T", 5999);
        playerhigh = PlayerPrefs.GetString("HiScorer", "Player1");
  
        if (CharacterChoose.playerbool)
        {
            player = player1;
            rb = rb1;
        }
        else if (CharacterChoose.dragonbool)
        {
            player = player2;
            rb = rb2;
        }
        else if (CharacterChoose.pokebool)
        {
            player = player3;
            rb = rb3;
        }
        timervar = 0;
        //Cursor.visible = false;
      
        spotlightoffset = new Vector3(-0.11f, 5.76f, -0.1f);
        enterenabledback = false;
        enterenablednext = false;

        
        
        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            score = 0;
            possibleHigh = 3;
            spotlightoffset = new Vector3(-0.11f, 5.76f, -0.71f);

        }
        if (SceneManager.GetActiveScene().name == "Scene3")
        {
            score = 3;
            possibleHigh = 9;
            speed = 27f;

        }
        if (SceneManager.GetActiveScene().name == "Scene4")
        {
            score = 9;
            possibleHigh = 17;

        }

        if (SceneManager.GetActiveScene().name == "Scene5")
        {
            score = 17;
            possibleHigh = 29;
            statuenum = Random.Range(1, 8);
            GameObject.Find("statue" + statuenum).gameObject.tag = "DirectEnd";
        }
        

        spotlight.SetActive(false);
        spotlight2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        spotlight.transform.position = player.transform.position + spotlightoffset;
        if (!timerstop)
        {
            timer();
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Scene2")
            {
                if ((timervar) < PlayerPrefs.GetFloat("Lvl1T", 5999f))
                {
                    PlayerPrefs.SetFloat("Lvl1T", timervar);
                    timetaken1 = timervar;
                }
                

            }
            else if (SceneManager.GetActiveScene().name == "Scene3")
            {
                if (timervar < PlayerPrefs.GetFloat("Lvl2T", 5999f))
                {

                    PlayerPrefs.SetFloat("Lvl2T", timervar);
                    timetaken2 = timervar;
                  
                }

            }
            else if (SceneManager.GetActiveScene().name == "Scene4")
            {
                if ((timervar) < PlayerPrefs.GetFloat("Lvl3T", 5999f))
                {
                    PlayerPrefs.SetFloat("Lvl3T", timervar);
                    timetaken3 = (timervar);
                }
            }
            else if (SceneManager.GetActiveScene().name == "Scene5")
            {
                if ((timervar) < PlayerPrefs.GetFloat("Lvl4T", 5999f))
                {
                    PlayerPrefs.SetFloat("Lvl4T", timervar);
                    timetaken4 = (timervar);
                }
            }
        }



            if (rb.velocity.magnitude < 2)
        {
            pSplayer.Stop();
        }
        else
        {
            if (!pSplayer.isPlaying)
            {
                pSplayer.Play();
            }
        }
        if (CameraController.fpsee)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                txtScore.text = "Total coins : " + possibleHigh;
                spotlight.SetActive(true);
                spotlight2.SetActive(true);

            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                spotlight.SetActive(false);
                spotlight2.SetActive(false);
                txtScore.text = "Score : " + score;
            }
        }
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            currenths = score;
            PlayerPrefs.SetString("HiScorer", playerhigh);
            playerhigh = playername;
        }
    }
            

    private void FixedUpdate()
    {

        if (!isGameover)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveForward = Input.GetAxis("Vertical");
            float moveVertical = Input.GetAxis("Jump");
         
                Vector3 movement = new Vector3(moveHorizontal, moveVertical, moveForward);
                rb.AddForce(movement * speed);
            
            }
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {

            Destroy(other.gameObject);
            score++;
            txtScore.text = "Score : " + score;
            if (SwitchScene.audiobool)
            {
                coinaudio.Play();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Walls")
        {

            if (SwitchScene.audiobool)
            {
                wallhitaudio.volume = 0.1f;
                wallhitaudio.Play();
            }
            
        }
        if (collision.gameObject.tag == "Bounds")
        {
            rb.isKinematic = true;
            outofBounds = true;
            Invoke("panel", 0.6f);

        }

        if (collision.gameObject.tag == "End")
        {
            Invoke("onEnd", 0.0f);
        }

        if (collision.gameObject.tag == "DirectEnd")
        {
            if (SwitchScene.audiobool)
            {
                nextlevelaudio.Play();
            }
            score = possibleHigh;
            Invoke("onEnd", 0.0f);
        }
        if (collision.gameObject.tag == "Plane")
        {
            if (SwitchScene.audiobool)
            {
                wallhitaudio.volume =  0.0075f;
                wallhitaudio.Play();
            }
            
        }

        if (collision.gameObject.tag == "Enemy")
        {
            isGameover = true;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            Destroy(collision.gameObject, 0.4f);
            Invoke("panel", 0.0f);
        }

        if (SceneManager.GetActiveScene().name == "Scene5")
        {
            if (collision.gameObject.tag == "Coin")
            {
                
                Destroy(collision.gameObject);
                score++;
                txtScore.text = "Score : " + score;
                if (SwitchScene.audiobool)
                {
                    coinaudio.Play();
                }
            }
        }
    }
        void onEnd()
        {
            Invoke("panel2", 0.0f);
        }

        void panel()
        {
            enterenabledback = true;
            panel1.SetActive(true);
            CameraController.fpsee = false;
            if (SwitchScene.audiobool)
            {
                gameoveraudio.Play();
            }

            if (!outofBounds)
            {
                    if (score == possibleHigh)
                    {
                        txt2.text = "Game Over, you collected all coins";
                        score = 0;

                    }       
                    else
                    {
                        txt2.text = "Game Over, your score was " + score;
                        score = 0;

                    }
            }
            else
            {
                txt2.text = "You were out of bounds!";
                score = 0;

            }
        }
        void panel2()
        {
            Cursor.visible = true;
            panelB.SetActive(true);
            CameraController.fpsee = false;
            if (score == possibleHigh)
            {
                if (SwitchScene.audiobool)
                {
                    nextlevelaudio.Play();
                }
                timerstop = true;
                enterenablednext = true;
                if (SceneManager.GetActiveScene().name != "Scene5")
                {
                    nexttxt.text = "Next Level";
                    endtxt.text = "You got to Level " + SceneManager.GetActiveScene().name.Substring(5, 1) + " with some finesse!";
               
                }
                else
                {
                    nexttxt.text = "Final Scene";
                    endtxt.text = "                        " + "You finally got to the end of the game!";

                }
                next.SetActive(true);
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }

            else
            {
                enterenabledback = true;
                next.SetActive(false);
                if (SwitchScene.audiobool)
                {
                    gameoveraudio.Play();
                }
                endtxt.text = "Oh no! You got to the end before getting all the coins!";
                score = 0;
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    void timer()
    {
        timervar += Time.deltaTime;
        ms = (int)((timervar * 100) % 100);
        seconds =(int)(timervar % 60);
        minutes = (int)((timervar / 60)%60);

        stopwatchtext.text = minutes.ToString("00") + " : " + seconds.ToString("00") + " : " + ms.ToString("00");

    }
   
    
}