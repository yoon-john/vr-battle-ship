using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;

    // Update is called once per frame
    
    void Update()
    {
        // Example: Move the object towards a specific coordinate (5, 0, 5)
        MoveTowardsCoordinate(new Vector3(10, 10, 5));
    }

    void MoveTowardsCoordinate(Vector3 targetPosition)
    {
        // Calculate the direction to the target position
        Vector3 direction = targetPosition - transform.position;

        // Check if the object is already at the target position
        if (direction.magnitude < 0.1f)
        {
            // Object is close enough to the target, no need to move
            return;
        }

        // Rotate the object to face the target position
        Quaternion toRotation = Quaternion.LookRotation(direction.normalized);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 360f);

        // Translate the object towards the target position
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
