using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition_To_Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other_object = collision.gameObject;

        if(other_object.GetComponent<Defenders>())
        {
            GetComponent<Enemy>().Attack(other_object);
        }
    }
}
