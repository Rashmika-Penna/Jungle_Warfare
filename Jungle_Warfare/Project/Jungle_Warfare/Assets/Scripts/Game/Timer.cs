using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float time = 10; // In seconds
    bool level_finish = false;

    private void Update()
    {
        if(level_finish)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / time;

        bool time_up = (Time.timeSinceLevelLoad >= time);

        if(time_up)
        {
            FindObjectOfType<Level_Controller>().Time_Up();
            level_finish = true;
        }        
    }
}
