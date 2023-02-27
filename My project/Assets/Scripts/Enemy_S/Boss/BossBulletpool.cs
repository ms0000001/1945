using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletpool : MonoBehaviour
{
    Transform target;
    public GameObject bulletPrefab;
    public GameObject[] gameObjects;
    public GameObject parents;
    private int pivot = 0;

    float timer;
    float setTime;
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;

        timer = 0;
        setTime = 0.6f;

        gameObjects = new GameObject[30];
        for(int i=0; i<30; i++){
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
        if(BossAct.cnt>200&&BossAct.cnt<500)
        {
            setTime =0.45f;
        }
        if(BossAct.cnt>500&&BossAct.cnt<701)
        {
            setTime =0.3f;
        }
    }
    void Shoot()
    {      
        if(Boomer.isFlying == false)
        {
            if(timer>setTime)
            {
                gameObjects[pivot].SetActive(true);
                Rigidbody2D rigid = gameObjects[pivot].GetComponent<Rigidbody2D>();
                rigid.AddForce(target.transform.position,ForceMode2D.Impulse);
                //rigid.AddForce(new Vector2(0,-2.5f),ForceMode2D.Impulse);
                gameObjects[pivot].transform.position = transform.position;
                timer = 0;
                pivot++;
                if(pivot == 30) pivot = 0;
            }
        }  
    }
}
