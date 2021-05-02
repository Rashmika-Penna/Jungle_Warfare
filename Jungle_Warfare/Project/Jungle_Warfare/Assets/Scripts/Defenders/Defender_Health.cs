using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender_Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    bool is_dead = false;
    
    public void Deal_Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            is_dead = true;
            Destroy(gameObject);
        }
    }
}
