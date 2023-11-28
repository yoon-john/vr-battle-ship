using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public string laserHittableTag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == laserHittableTag)
        {
            other.transform.parent.GetComponent<Ship>().loseHealth(10);

            Destroy(gameObject); 
        }
    }
}
