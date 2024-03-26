using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Text highscore , L1T, L2T, L3T, L4T, highscorer;
    // Start is called before the first frame update
    void Start()
    {
        //Player Data
        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        L1T.text = ((int)((PlayerPrefs.GetFloat("Lvl1T") / 60) % 60)).ToString("00") + " : " + ((int)(PlayerPrefs.GetFloat("Lvl1T") % 60)).ToString("00") + " : " + ((int)((PlayerPrefs.GetFloat("Lvl1T") * 100) % 100)).ToString("00");
        L2T.text = ((int)((PlayerPrefs.GetFloat("Lvl2T") / 60) % 60)).ToString("00") + " : " + ((int)(PlayerPrefs.GetFloat("Lvl2T") % 60)).ToString("00") + " : " + ((int)((PlayerPrefs.GetFloat("Lvl2T") * 100) % 100)).ToString("00");
        L3T.text = ((int)((PlayerPrefs.GetFloat("Lvl3T") / 60) % 60)).ToString("00") + " : " + ((int)(PlayerPrefs.GetFloat("Lvl3T") % 60)).ToString("00") + " : " + ((int)((PlayerPrefs.GetFloat("Lvl3T") * 100) % 100)).ToString("00");
        L4T.text = ((int)((PlayerPrefs.GetFloat("Lvl4T") / 60) % 60)).ToString("00") + " : " + ((int)(PlayerPrefs.GetFloat("Lvl4T") % 60)).ToString("00") + " : " + ((int)((PlayerPrefs.GetFloat("Lvl4T") * 100) % 100)).ToString("00");

        highscorer.text = PlayerPrefs.GetString("HiScorer");
    }
    // Update is called once per frame
    void Update()
    {
    }
}
