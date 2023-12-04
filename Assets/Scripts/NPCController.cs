using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private GameObject FindClosestShip()
    {
        GameObject[] ships;
        ships = GameObject.FindGameObjectsWithTag("ship");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject ship in ships)
        {
            float distance = Vector3.Distance(ship.transform.position, currentPosition);
            if (distance < minDistance)
            {
                closest = ship;
                minDistance = distance;
            }
        }

        return closest;
    }

    ObjectMovement m_objectMovement;
    Ship m_ship;

    [HideInInspector]
    public GameObject closestShip = null; 

    private void Start()
    {
        m_objectMovement = GetComponent<ObjectMovement>();
        m_ship = GetComponent<Ship>(); 
    }

    private void Update()
    {
        if (closestShip == null) closestShip = FindClosestShip();

        if (!m_ship.GetAttacking()) m_objectMovement.coordinate = closestShip.transform.position;
    }
}