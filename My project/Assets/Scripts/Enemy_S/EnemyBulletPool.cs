using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject[] gameObjects;
    public Transform point;
    public GameObject parents;
    private int pivot = 0;

    float timer;
    float setTime;
    void Start()
    {
        timer = 0;
        setTime = 1f;
        //탄환 생성
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
        timer += Time.deltaTime;
        Shoot();
    }
    
    //사격
    void Shoot()
    {
        //사격 딜레이
        if(timer>setTime)
        {
            gameObjects[pivot].SetActive(true);
            Rigidbody2D rigid = gameObjects[pivot].GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down*5,ForceMode2D.Impulse);
            gameObjects[pivot].transform.position = transform.position;
            timer = 0;
            pivot++;
            if (pivot == 20) pivot = 0;
        }
    }
}
