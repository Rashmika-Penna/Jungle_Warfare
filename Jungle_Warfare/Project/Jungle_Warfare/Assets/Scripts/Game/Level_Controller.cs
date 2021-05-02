using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Controller : MonoBehaviour
{
    [SerializeField] float wait_to_load = 3;
    [SerializeField] Canvas win_canvas = null;
    int attackers_alive = 0;
    bool time_up = false;

    private void Start()
    {
        win_canvas.enabled = false;
    }

    public void Enemies_Spawned()
    {
        attackers_alive++;
    }

    public void Enemies_Killed()
    {
        attackers_alive--;

        if(attackers_alive <= 0 && time_up)
        {
            StartCoroutine(Handle_Win_Condition());
        }
    }
    
    public void Time_Up()
    {
        time_up = true;
        Stop_Spawners();
    }

    private void Stop_Spawners()
    {
        Enemy_Spawner[] spawner_array = FindObjectsOfType<Enemy_Spawner>();

        foreach(Enemy_Spawner spawner in spawner_array)
        {
            spawner.Stop_Spawning();
        }
    }

    IEnumerator Handle_Win_Condition()
    {
        win_canvas.enabled = true;
        GetComponent<AudioSource>().Play();        
        yield return new WaitForSeconds(wait_to_load);
        FindObjectOfType<Screen_Loader>().Start_Screen();
    }
}
