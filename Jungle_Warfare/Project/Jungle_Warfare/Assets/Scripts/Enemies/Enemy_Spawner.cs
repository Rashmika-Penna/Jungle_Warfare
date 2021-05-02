using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemies = null;
    [SerializeField] float min_spawn_time = 0f;
    [SerializeField] float max_spawn_time = 0f;
    bool spawn = true;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(min_spawn_time, max_spawn_time));
            Spawn_Enemy();
        }
    }

    private void Spawn_Enemy()
    {
        var enemy_index = Random.Range(0, enemies.Length);
        Spawn(enemies[enemy_index]);
    }

    private void Spawn(Enemy enemy)
    {
        Enemy new_enemy = Instantiate(enemy, transform.position, transform.rotation) as Enemy;
        new_enemy.transform.parent = transform;
        // Setting the prefab's transform to the spawner's [parent] 
        // So that we can give a condition that 
        // When the spawner has more than zero children under each spawner [spawner1, spawner2, spawner3...]
        // We can make the defender attack the spawned enemy
    }

    public void Stop_Spawning()
    {
        spawn = false;
    }
}
