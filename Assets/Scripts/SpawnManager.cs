using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public float spawnTime;
    public GameObject shipPrefab;
    public GameObject[] shipList = new GameObject[5];

    public void Spawn(int i)
    {
        Transform spawn = spawnLocations[i];
        GameObject ship = Instantiate(shipPrefab, spawn.position, spawn.rotation);
        shipList[i] = ship;
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn(0);
        Spawn(1);
        shipList[0].GetComponent<Ship>().attackTarget(shipList[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
