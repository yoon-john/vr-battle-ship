using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Vector3 coordinate;
    public float rotationSpeed = 5f;

    private bool status = true;

    private bool attack = false; 

    void Update()
    {
        if (CheckMoveRequired(coordinate))
        {
            MoveTowardsCoordinate(coordinate);
        }
        if (attack)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * movementSpeed * 10f);

        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    Vector3 directionToTarget;

    GameObject targetShip = null; 

    private void OnTriggerEnter(Collider other)
    {
        if (targetShip == null && IsOpponentShip(other))
        {
            status = false;
            targetShip = other.gameObject; 
            coordinate = transform.position; 

            directionToTarget = other.transform.position - transform.position;
            directionToTarget.y = 0f;

            attack = true; 
        }
    }

    // You might want to add OnTriggerExit to set status back to true when the ship exits the radius
    private void OnTriggerExit(Collider other)
    {
        if (targetShip == other.gameObject)
        {
            status = true;
            targetShip = null; 
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
