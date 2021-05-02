using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    [SerializeField] float projectile_speed = 2f;
    [SerializeField] int damage = 5;
    
    private void Update()
    {
        transform.Translate(Vector2.right * projectile_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var enemy = collision.GetComponent<Enemy>();

        if(enemy && health)
        {
            health.Deal_Damage(damage);
            Destroy(gameObject);
        }
    }
}
