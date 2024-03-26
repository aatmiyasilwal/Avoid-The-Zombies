using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gohome ()
    {
        SceneManager.LoadScene("Scene0");
    }
    public void lvl1()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void lvl2()
    {
        SceneManager.LoadScene("Scene3");
    }
    public void lvl3()
    {
        SceneManager.LoadScene("Scene4");
    }
    public void lvl4()
    {
        SceneManager.LoadScene("Scene5");
    }
    public void lvl5()
    {
        SceneManager.LoadScene("Scene6");
    }
}

