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

    static List<GameObject> overlappedShips = new List<GameObject>();

    public static GameObject GetOverlapShip()
    {
        if (overlappedShips.Count != 0)
        {
            return overlappedShips[0]; 
        }
        return null; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shipSelectArea")
        {
            overlappedShips.Add(other.transform.parent.gameObject);
            other.transform.parent.GetComponent<Highlight>().ToggleHover(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "shipSelectArea")
        {
            overlappedShips.Remove(other.transform.parent.gameObject);
            other.transform.parent.GetComponent<Highlight>().ToggleHover(false);
        }
    }
}
