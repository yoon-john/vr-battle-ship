using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    //we assign all the renderers here through the inspector
    [SerializeField]
    private Renderer selectDisplay; 

    public void ToggleHover(bool val)
    {
        selectDisplay.enabled = val;
        if (!val)
        {
            ToggleHighlight(false); 
        }
    }

    public void ToggleHighlight(bool val)
    {
        if (val)
        {
            selectDisplay.material.color = new Color(0.65f, 0.8f, 1f, 0.4f);
        }
        else
        {
            selectDisplay.material.color = new Color(0.65f, 0.8f, 1f, 0f);
        }
    }
}
