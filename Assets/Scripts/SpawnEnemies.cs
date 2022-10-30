using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<Vector3> spawnLocations;
    public List<GameObject> spawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        var spawners = GameObject.FindGameObjectsWithTag("spawner");
        foreach (var spawner in spawners)
        {
            var spawnLocation = spawner.transform.position;
            spawnLocations.Add(spawnLocation);
        }
        StartCoroutine(SpawnEnemy());
        //Instantiate(spawnObjects[0], spawnLocations[0], Quaternion.identity);
        //Instantiate(spawnObjects[1], spawnLocations[1], Quaternion.identity);
        //Instantiate(spawnObjects[2], spawnLocations[2], Quaternion.identity);
        //Instantiate(spawnObjects[3], spawnLocations[3], Quaternion.identity);

    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = ObjectPool.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                enemy.transform.position = spawnLocations[3];
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
