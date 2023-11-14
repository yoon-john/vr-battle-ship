using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
     public float movementSpeed = 5f;
    public Vector3 coordinate;
    public float rotationSpeed = 5f;

    private bool status = true;

    void Update()
    {
        if (status)
        {
            MoveTowardsCoordinate(coordinate);
        }
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ship"))
        {
            status = false;
            Vector3 directionToTarget = other.transform.position - transform.position;
            directionToTarget.y = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // You might want to add OnTriggerExit to set status back to true when the ship exits the radius
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ship"))
        {
            status = true;
        }
    }
}
