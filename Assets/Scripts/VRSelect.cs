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
            bool rightSelect;
            if (leftControllerSelect.action.ReadValue<float>() != 0) rightSelect = false;
            else rightSelect = true;

            // Check if click overlaps with friendly ship -> update info on what ship is selected
            if (ShipSelector.GetOverlapShip(rightSelect) != null)
            {
                selectedGO = ShipSelector.GetOverlapShip(rightSelect);
                selectedGO.GetComponent<Highlight>().ToggleHighlight(true); 
            }
            else // move the selected ship to the location of controller
            {
                Vector3 moveToPos;

                if (leftControllerSelect.action.ReadValue<float>() != 0)
                {
                    moveToPos = leftController.transform.position; 
                }
                else 
                {
                    moveToPos = rightController.transform.position;
                }

                if (selectedGO != null) selectedGO.GetComponent<ObjectMovement>().coordinate = moveToPos; 
            }
        }
    }


}
