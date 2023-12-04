using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    //we assign all the renderers here through the inspector
    [SerializeField]
    private Renderer selectDisplay;

    public bool selected = false;

    VRSelect m_VRSelect; 

    private void Start()
    {
        m_VRSelect = FindObjectOfType<VRSelect>(); 

        ToggleHover(false); 
    }

    public void ToggleHover(bool val)
    {
        selectDisplay.enabled = val;
    }

    public void ToggleHighlight(bool val)
    {
        if (val)
        { 
            selectDisplay.material.color = new Color(0.65f, 0.8f, 1f, 0.4f);
            selected = true; 
        }
        else
        {
            selectDisplay.material.color = new Color(0.65f, 0.8f, 1f, 0.1f);
            selected = false;
        }
    }
}
