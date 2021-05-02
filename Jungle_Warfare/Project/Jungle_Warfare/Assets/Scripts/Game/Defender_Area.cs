using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender_Area : MonoBehaviour
{
    Defenders defender = null;

    private void OnMouseDown()
    {
        Placing_Defender_Check(Get_Square_Clicked());        
    }

    private Vector2 Get_Square_Clicked()
    {
        Vector2 screen_mouse_pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 world_pos = Camera.main.ScreenToWorldPoint(screen_mouse_pos);
        Vector2 grid_pos = Snap_To_Grid(world_pos);
        return grid_pos;
    }

    private Vector2 Snap_To_Grid(Vector2 raw_world_pos)
    {
        float new_x = Mathf.RoundToInt(raw_world_pos.x);
        float new_y = Mathf.RoundToInt(raw_world_pos.y);
        return new Vector2(new_x, new_y);
    }

    private void Spawn_Defender(Vector2 rounded_world_pos)
    {
        Defenders new_defender = Instantiate(defender, rounded_world_pos, Quaternion.identity) as Defenders;
    }

    public void Spawn_Selected_Defender(Defenders selected_defender)
    {
        defender = selected_defender;
    }

    private void Placing_Defender_Check(Vector2 defender_pos)
    {
        var mushroom_display = FindObjectOfType<Mushroom_Currency_Display>();
        int defender_cost = defender.Get_Defender_Mushroom_Cost();

        if(mushroom_display.Do_You_Have_Enough_Mushrooms(defender_cost))
        {
            Spawn_Defender(defender_pos);
            mushroom_display.Spend_Mushrooms(defender_cost);
        }
    }
}
