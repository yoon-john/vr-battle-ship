using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Vector3 coordinate;
    public float rotationSpeed = 5f;

    private bool attack = false;

    private Ship m_ship;

    private void Start()
    {
        m_ship = GetComponent<Ship>(); 
    }

    void Update()
    {
        if (CheckMoveRequired(coordinate))
        {
            MoveTowardsCoordinate(coordinate);
        }
        if (attack && targetShip != null)
        {
            directionToTarget = targetShip.transform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else if (attack && targetShip == null)
        {
            m_ship.StopAttack();
        }
    }

    bool CheckMoveRequired(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        if (direction.magnitude >= 0.1f)
        {
            attack = false; 
            return true;
        }
        return false; 
    }

    void MoveTowardsCoordinate(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;

        if (direction.magnitude < 0.1f)
        {
            return;
        }

        Quaternion toRotation = Quaternion.LookRotation(direction.normalized);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * rotationSpeed * 10f);

        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    Vector3 directionToTarget;

    GameObject targetShip = null; 

    private void OnTriggerStay(Collider other)
    {
        if (targetShip == null && IsOpponentShip(other))
        {

            targetShip = other.gameObject;
            m_ship.StartAttack(targetShip);

            coordinate = transform.position; 

            attack = true; 
        }
    }

    // You might want to add OnTriggerExit to set status back to true when the ship exits the radius
    private void OnTriggerExit(Collider other)
    {
        if (targetShip == other.gameObject)
        {
            targetShip = null;
            m_ship.StopAttack();
        }
    }

    private bool IsOpponentShip(Collider other)
    {
        if (gameObject.tag == "ship" && other.tag == "enemy")
        {
            return true; 
        }
        else if (gameObject.tag == "enemy" && other.tag == "ship")
        {
            return true; 
        }
        return false; 
    }
}
