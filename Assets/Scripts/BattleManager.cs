using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private int usership_count = 0;
    private int enemyship_count = 0;

    public enum Team
    {
        user,
        enemy
    };

    public enum ShipType
    {
        regular
    };

    [SerializeField]
    private GameObject[] userShips;

    [SerializeField]
    private GameObject[] enemyShips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnShip(Team team, ShipType shipType, Vector3 location)
    {
        if (team == Team.user)
        {
            Instantiate(userShips[(int)shipType], location, Quaternion.identity);
            usership_count++;
        }
        if (team == Team.enemy)
        {
            Instantiate(enemyShips[(int)shipType], location, Quaternion.identity);
            enemyship_count++; 
        }
    }
}
