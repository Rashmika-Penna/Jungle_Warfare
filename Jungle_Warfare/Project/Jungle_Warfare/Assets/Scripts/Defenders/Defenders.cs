using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    [SerializeField] int defender_cost = 100;
    GameObject enemy;

    public void Update_Mushroom_Display(int amount)
    {
        FindObjectOfType<Mushroom_Currency_Display>().Add_Mushrooms(amount);
        Update_Animation_State();
    }

    public int Get_Defender_Mushroom_Cost()
    {
        return defender_cost;
    }

    public void Attack(GameObject enemy_target)
    {
        GetComponent<Animator>().SetBool("Attacking", true);
        enemy = enemy_target;
    }

    public void Hurt_Enemy(int damage)
    {
        if(!enemy)
        {
            return;
        }

        Health health = enemy.GetComponent<Health>();

        if(health)
        {
            health.Deal_Damage(damage);
        }
    }

    private void Update_Animation_State()
    {
        if(!enemy)
        {
            GetComponent<Animator>().SetBool("Attacking", false);
        }
    }
}
