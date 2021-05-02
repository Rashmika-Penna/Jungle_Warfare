using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] GameObject projectile_point = null;
    Enemy_Spawner lane_spawner;
    Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        Setting_Lane_Spawner();
    }

    private void Update()
    {
        if(Is_Enemy_In_Lane())
        {
            animator.SetBool("Attacking", true);
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
    }

    public void Fire()
    {
        Instantiate(projectile, projectile_point.transform.position, Quaternion.identity);
    }

    private void Setting_Lane_Spawner()
    {
        Enemy_Spawner[] spawners = FindObjectsOfType<Enemy_Spawner>();

        foreach(Enemy_Spawner spawner in spawners)
        {
            bool is_close_enough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if(is_close_enough)
            {
                lane_spawner = spawner;
            }
        }
    }

    private bool Is_Enemy_In_Lane()
    {
        if(lane_spawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
