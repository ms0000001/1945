using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] gameObjects;
    public Transform point;
    public GameObject parents;
    private int pivot = 0;

    float timer;
    float setTime;
    void Start()
    {
        timer = 0;
        setTime = 8f;

        gameObjects = new GameObject[20];
        for(int i=0; i<20; i++){
            GameObject enemy = Instantiate(enemyPrefab);
            gameObjects[i] = enemy;
            enemy.transform.SetParent(parents.transform.parent);
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        Spawn();
    }
    void Spawn()
    {
        if(timer>setTime)
        {
            gameObjects[pivot].SetActive(true);
            gameObjects[pivot].transform.position = transform.position;
            timer = 0;
            pivot++;
            if (pivot == 20) pivot = 0;
        }
    }
}
