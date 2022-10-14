using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnEnemies : MonoBehaviour
{
    public List<Vector3> spawnLocations;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        var spawners = GameObject.FindGameObjectsWithTag("spawner");
        foreach(var spawner in spawners)
        {
            var spawnLocation = spawner.transform.position;
            spawnLocations.Add(spawnLocation);
        }
        Instantiate(enemy, spawnLocations[0], Quaternion.identity);
        Instantiate(enemy, spawnLocations[1], Quaternion.identity);
        Instantiate(enemy, spawnLocations[2], Quaternion.identity);
        Instantiate(enemy, spawnLocations[3], Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
