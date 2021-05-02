using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pause_menu;

    private void Start()
    {
        pause_menu.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void Pause()
    {
        pause_menu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Load_Menu()
    {
        FindObjectOfType<Screen_Loader>().Start_Screen();
    }

    public void Quit_Game()
    {
        FindObjectOfType<Screen_Loader>().Quit();
    }
}
