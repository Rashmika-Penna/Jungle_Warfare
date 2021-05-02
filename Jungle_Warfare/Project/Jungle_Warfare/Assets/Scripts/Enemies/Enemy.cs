using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float current_walk_speed = 0f;
    GameObject defender;

    private void Awake()
    {
        FindObjectOfType<Level_Controller>().Enemies_Spawned();
    }

    private void OnDestroy()
    {
        Level_Controller level_controller = FindObjectOfType<Level_Controller>();
        if (level_controller != null)
        {
            level_controller.Enemies_Killed();
        }        
    }

    private void Update()
    {
        transform.Translate(Vector2.left * current_walk_speed * Time.deltaTime);
        Update_Animation_State();
    }

    public void Set_Movement_Speed(float movement_speed)
    {
        current_walk_speed = movement_speed;
    }

    public void Attack(GameObject defender_target)
    {
        GetComponent<Animator>().SetBool("Attacking", true);
        defender = defender_target;
    }

    public void Cause_Damage(int damage)
    {
        if(!defender)
        {
            return;
        }

        Defender_Health health = defender.GetComponent<Defender_Health>();

        if(health)
        {
            health.Deal_Damage(damage);
        }        
    }

    private void Update_Animation_State()
    {
        if(!defender)
        {
            GetComponent<Animator>().SetBool("Attacking", false);
        }
    }
}
