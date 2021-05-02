using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over_Collider : MonoBehaviour
{
    Screen_Loader screen_loader;

    private void Start()
    {
        screen_loader = FindObjectOfType<Screen_Loader>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        screen_loader.Load_Game_Over_Screen();
    }
}
