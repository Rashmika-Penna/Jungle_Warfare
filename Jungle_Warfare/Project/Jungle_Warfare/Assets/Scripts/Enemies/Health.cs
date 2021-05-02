using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    bool is_dead = false;

    public void Deal_Damage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            is_dead = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Animator>().SetTrigger("Die");
            Destroy(gameObject, 1.5f);
        }
    }
}
