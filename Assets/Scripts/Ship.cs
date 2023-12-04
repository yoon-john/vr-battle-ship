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
    [HideInInspector]
    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    GameObject m_attackTarget;

    float timeUntilNextAttack = 0f; 
    float attackCD = 1f; 

    // Update is called once per frame
    void Update()
    {
        if (attacking && Time.time > timeUntilNextAttack)
        {
            Attack(m_attackTarget); 
            timeUntilNextAttack = Time.time + attackCD; 
        }
    }

    void moveShip(Vector3 destination)
    {
        // add Eugene's moveShip implementation later.
    }

    bool attacking = false;

    public bool GetAttacking()
    {
        return attacking; 
    }

    public void StartAttack(GameObject target)
    {
        attacking = true;
        m_attackTarget = target; 
    }

    public void StopAttack()
    {
        attacking = false; 
    }

    public GameObject laserPrefab;

    private void Attack(GameObject target)
    {
        GameObject spawnedLaser = Instantiate(laserPrefab, transform.position + transform.TransformDirection(Vector3.forward * 0.2f), transform.rotation);
        spawnedLaser.transform.Rotate(new Vector3(90f, 0, 0));
        spawnedLaser.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 0.5f);

        /*
        Ship script = target.GetComponent<Ship>();
        script.loseHealth(damage);
        */
    }

    public void loseHealth(int damage)
    {
        currHealth -= damage;
        Debug.Log("lose Health: " + currHealth);
        if (currHealth <= 0) {
            Die();
        }
    }

    void Die() 
    {
        if (this.tag == "enemy")
        {
            spawnManager.enemyShipNum--;
            Debug.Log(spawnManager.enemyShipNum);
        }
        else if (this.tag == "ship")
        {
            spawnManager.userShipNum--;
            Debug.Log(spawnManager.userShipNum);
        }
        Debug.Log("dead");
        GameObject.Destroy(gameObject);
    }
}
