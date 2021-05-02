using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mushroom_Currency_Display : MonoBehaviour
{
    [SerializeField] int mushrooms = 100;
    Text mushroom_currency_display;

    private void Start()
    {
        mushroom_currency_display = GetComponent<Text>();
        Display_Currency();
    }

    private void Display_Currency()
    {
        mushroom_currency_display.text = mushrooms.ToString();
    }

    public void Add_Mushrooms(int add_amount)
    {
        mushrooms += add_amount;
        Display_Currency();
    }

    public void Spend_Mushrooms(int spend_amount)
    {
        if(mushrooms >= spend_amount)
        {
            mushrooms -= spend_amount;
            Display_Currency();
        }  
        // else black out the defender icons
    }

    public bool Do_You_Have_Enough_Mushrooms(int amount)
    {
        return mushrooms >= amount;
    }
}
