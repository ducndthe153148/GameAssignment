using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public List<Vector3> spawnLocations;
    private float TimeUpdate = 60;
    private float timeToSpawn = 4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy1());
        StartCoroutine(SpawnEnemy2());
        StartCoroutine(SpawnEnemy3());
        StartCoroutine(SpawnEnemy4());
    }

    private IEnumerator SpawnEnemy1()
    {
        while (true)
        {
            var check = Random.Range(1, 4);
            GameObject enemy = ObjectPool1.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                if (check == 1)
                {
                    enemy.transform.position = new Vector3(3.99f, Random.Range(-1.63f, 1.59f), 0);
                }
                else if (check == 2)
                {
                    enemy.transform.position = new Vector3(-3.92f, Random.Range(-1.63f, 1.59f), 0);
                }
                else if (check == 3)
                {
                    enemy.transform.position = new Vector3(Random.Range(-3.92f, 3.99f), -1.63f, 0);
                }
                else
                {
                    enemy.transform.position = new Vector3(Random.Range(-3.92f, 3.99f), 1.59f, 0);
                }
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    private IEnumerator SpawnEnemy2()
    {
        while (true)
        {
            var check = Random.Range(1, 4);
            GameObject enemy = ObjectPool2.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                if (check == 1)
                {
                    enemy.transform.position = new Vector3(3.99f, Random.Range(-1.63f, 1.59f), 0);
                }
                else if (check == 2)
                {
                    enemy.transform.position = new Vector3(-3.92f, Random.Range(-1.63f, 1.59f), 0);
                }
                else if (check == 3)
                {
                    enemy.transform.position = new Vector3(Random.Range(-3.92f, 3.99f), -1.63f, 0);
                }
                else
                {
                    enemy.transform.position = new Vector3(Random.Range(-3.92f, 3.99f), 1.59f, 0);
                }
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    private IEnumerator SpawnEnemy3()
    {
        while (true)
        {
            var check = Random.Range(1, 4);
            GameObject enemy = ObjectPool3.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                if (check == 1)
                {
                    enemy.transform.position = new Vector3(3.99f, Random.Range(-1.63f, 1.59f), 0);
                }
                else if (check == 2)
                {
                    enemy.transform.position = new Vector3(-3.92f, Random.Range(-1.63f, 1.59f), 0);
                }
                else if (check == 3)
                {
                    enemy.transform.position = new Vector3(Random.Range(-3.92f, 3.99f), -1.63f, 0);
                }
                else
                {
                    enemy.transform.position = new Vector3(Random.Range(-3.92f, 3.99f), 1.59f, 0);
                }
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    private IEnumerator SpawnEnemy4()
    {
        while (true)
        {
            var check = Random.Range(1, 4);
            GameObject enemy = ObjectPool4.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                if (check == 1)
                {
                    enemy.transform.position = new Vector3(3.99f, Random.Range(-1.63f, 1.59f), 0);
                }
                else if (check == 2)
                {
                    enemy.transform.position = new Vector3(-3.92f, Random.Range(-1.63f, 1.59f), 0);
                }
                else if (check == 3)
                {
                    enemy.transform.position = new Vector3(Random.Range(-3.92f, 3.99f), -1.63f, 0);
                }
                else
                {
                    enemy.transform.position = new Vector3(Random.Range(-3.92f, 3.99f), 1.59f, 0);
                }
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeUpdate -= Time.deltaTime;
        if(TimeUpdate < 0)
        {
            timeToSpawn = 3;
        }
    }
}
