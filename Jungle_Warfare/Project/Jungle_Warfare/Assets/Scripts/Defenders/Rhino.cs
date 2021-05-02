using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : MonoBehaviour
{
    [SerializeField] float current_walk_speed = 0f;
    [SerializeField] int damage = 5;

    private void Update()
    {
        transform.Translate(Vector2.right * current_walk_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other_object = collision.gameObject;

        if (other_object.GetComponent<Enemy>())
        {
            GetComponent<Defenders>().Attack(other_object);
            GetComponent<Defenders>().Hurt_Enemy(damage);
        }

        Destroy(gameObject, 5f);
    }

    public void Set_Movement_Speed(float movement_speed)
    {
        current_walk_speed = movement_speed;
    }
}
