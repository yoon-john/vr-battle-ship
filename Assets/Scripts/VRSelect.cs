using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRSelect : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;

    private GameObject selectedGO = null;

    public string[] selectableTags;
    
    [SerializeField] public InputActionReference leftControllerSelect;
    [SerializeField] public InputActionReference rightControllerSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftControllerSelect.action.ReadValue<float>() != 0 || rightControllerSelect.action.ReadValue<float>() != 0)
        {
            // Check if click overlaps with friendly ship
            GameObject selectedGO = ShipSelector.GetOverlapShip(); 
            if (selectedGO != null)
            {
                selectedGO.GetComponent<Highlight>().ToggleHighlight(true); 
            }
        }
    }


}
