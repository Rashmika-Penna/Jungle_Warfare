using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen_Loader : MonoBehaviour
{
    int current_scene_index;
    [SerializeField] int wait_time = 3;

    private void Start()
    {
        current_scene_index = SceneManager.GetActiveScene().buildIndex;

        if(current_scene_index == 0)
        {
            StartCoroutine(Load_Start_Scene());
        }
    }

    IEnumerator Load_Start_Scene()
    {
        yield return new WaitForSeconds(wait_time);
        Load_Next_Scene();
    }

    public void Load_Next_Scene()
    {
        SceneManager.LoadScene(current_scene_index + 1);
    }

    public void Load_Game_Over_Screen()
    {
        SceneManager.LoadScene("Game_Over");
    }

    public void Start_Screen()
    {
        SceneManager.LoadScene("Start_Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause_Button()
    {
        Time.timeScale = 0;
    }

    public void Load_Game()
    {
        SceneManager.LoadScene("Game");
    }
}
