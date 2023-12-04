using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static List<GameObject> rightOverlappedShips = new List<GameObject>();
    static List<GameObject> leftOverlappedShips = new List<GameObject>();

    public static GameObject GetOverlapShip(bool rightSelect)
    {
        if (rightSelect && rightOverlappedShips.Count != 0)
        {
            return rightOverlappedShips[0]; 
        }
        else if (!rightSelect && leftOverlappedShips.Count != 0)
        {
            return leftOverlappedShips[0]; 
        }
        return null; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shipSelectArea")
        {
            if (gameObject.name == "Left Controller")
            {
                leftOverlappedShips.Add(other.transform.parent.gameObject);
            }
            else if (gameObject.name == "Right Controller")
            {
                rightOverlappedShips.Add(other.transform.parent.gameObject);
            }
            other.transform.parent.GetComponent<Highlight>().ToggleHover(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "shipSelectArea")
        {
            if (gameObject.name == "Left Controller")
            {
                leftOverlappedShips.Remove(other.transform.parent.gameObject);
            }
            else if (gameObject.name == "Right Controller")
            {
                rightOverlappedShips.Remove(other.transform.parent.gameObject);
            }
            if (!other.transform.parent.GetComponent<Highlight>().selected) other.transform.parent.GetComponent<Highlight>().ToggleHover(false);
            //other.transform.parent.GetComponent<Highlight>().ToggleHover(false);
        }
    }
}
