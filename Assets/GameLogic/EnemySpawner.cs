using GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int SpawnRate = 5;
    public Enemy EnemyPrefab;

    GameObject Player;
    float TimeSinceLastSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        TimeSinceLastSpawn += Time.deltaTime;
        if (TimeSinceLastSpawn > SpawnRate)
        {
            var pos = Movement.GetRandomPositionAtDistance(Player.transform.position, 10);
            Instantiate(EnemyPrefab, pos, Quaternion.identity);
            TimeSinceLastSpawn = 0;
        }
    }
}
