using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icons : MonoBehaviour
{
    [SerializeField] Image icon = null;
    [SerializeField] Defenders defender = null;   

    private void OnMouseOver()
    {
        var icons = FindObjectsOfType<Icons>();
        foreach(Icons icon in icons)
        {
            icon.GetComponent<Image>().color = Color.black;
        }

        icon.GetComponent<Image>().color = Color.white;
        FindObjectOfType<Defender_Area>().Spawn_Selected_Defender(defender);
    }
}
