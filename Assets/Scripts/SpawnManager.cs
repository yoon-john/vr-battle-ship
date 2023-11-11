using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public float spawnTime;
    public GameObject shipPrefab;

    public void Spawn()
    {
        Transform spawn = spawnLocations[Random.Range(0, spawnLocations.Length)];
        GameObject ship = Instantiate(shipPrefab, spawn.position, spawn.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
