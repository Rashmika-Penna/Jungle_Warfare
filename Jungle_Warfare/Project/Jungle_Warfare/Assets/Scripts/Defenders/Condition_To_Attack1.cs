using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition_To_Attack1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other_object = collision.gameObject;

        if(other_object.GetComponent<Enemy>())
        {
            GetComponent<Defenders>().Attack(other_object);
        }
    }
}
