using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] userSpawnLocations;
    public Transform[] enemySpawnLocations;
    public float spawnTime;
    public GameObject userShip;
    public GameObject enemyShip;
    public GameObject[] userShipList = new GameObject[5];
    public GameObject[] enemyShipList = new GameObject[5];

    public void UserSpawn(int i)
    {
        Transform spawn = userSpawnLocations[i];
        GameObject ship = Instantiate(userShip, spawn.position, spawn.rotation);
        userShipList[i] = ship;

        ship.GetComponent<ObjectMovement>().coordinate = ship.transform.position; 
    }

    public void EnemySpawn(int i)
    {
        Transform spawn = enemySpawnLocations[i];
        GameObject ship = Instantiate(enemyShip, spawn.position, spawn.rotation);
        enemyShipList[i] = ship;

        ship.GetComponent<ObjectMovement>().coordinate = ship.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            UserSpawn(i);
            EnemySpawn(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
