using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int maxHealth;
    private int currHealth;
    public int range;
    public int speed;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moveShip(Vector3 destination)
    {
        // add Eugene's moveShip implementation later.
    }

    public void attackTarget(GameObject target)
    {
        Debug.Log("attack");
        if (target.CompareTag("Ship")) {
                Ship script = target.GetComponent<Ship>();
                script.loseHealth(damage);
            }
    }

    public void loseHealth(int damage)
    {
        Debug.Log("lose Health");
        currHealth -= damage;
        if (currHealth <= 0) {
            Die();
        }
    }

    void Die() 
    {
        Debug.Log("dead");
        GameObject.Destroy(gameObject);
    }
}
