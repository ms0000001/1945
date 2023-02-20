using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpooling : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject[] gameObjects;
    public Transform point;
    public GameObject parents;
    private int pivot = 0;
    void Start()
    {
        gameObjects = new GameObject[20];
        for(int i=0; i<20; i++){
            GameObject bullet = Instantiate(bulletPrefab);
            gameObjects[i] = bullet;
            bullet.transform.SetParent(parents.transform.parent);
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameObjects[pivot].SetActive(true);
            Rigidbody2D rigid = gameObjects[pivot].GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.up*10,ForceMode2D.Impulse);
            gameObjects[pivot].transform.position = transform.position;
            pivot++;
            if (pivot == 20) pivot = 0;
        }
    }
}
