using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<Vector3> spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        var spawners = GameObject.FindGameObjectsWithTag("spawner");
        foreach (var spawner in spawners)
        {
            var spawnLocation = spawner.transform.position;
            spawnLocations.Add(spawnLocation);
        }
        StartCoroutine(SpawnEnemy1());
        StartCoroutine(SpawnEnemy2());
        StartCoroutine(SpawnEnemy3());
        StartCoroutine(SpawnEnemy4());
        //Instantiate(spawnObjects[0], spawnLocations[0], Quaternion.identity);
        //Instantiate(spawnObjects[1], spawnLocations[1], Quaternion.identity);
        //Instantiate(spawnObjects[2], spawnLocations[2], Quaternion.identity);
        //Instantiate(spawnObjects[3], spawnLocations[3], Quaternion.identity);

    }

    private IEnumerator SpawnEnemy1()
    {
        while (true)
        {
            GameObject enemy = ObjectPool1.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                enemy.transform.position = spawnLocations[0];
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(2);
        }
    }
    private IEnumerator SpawnEnemy2()
    {
        while (true)
        {
            GameObject enemy = ObjectPool2.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                enemy.transform.position = spawnLocations[1];
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(2);
        }
    }
    private IEnumerator SpawnEnemy3()
    {
        while (true)
        {
            GameObject enemy = ObjectPool3.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                enemy.transform.position = spawnLocations[2];
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(2);
        }
    }
    private IEnumerator SpawnEnemy4()
    {
        while (true)
        {
            GameObject enemy = ObjectPool4.SharedInstance.GetPooledObject();
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
