using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpooling : MonoBehaviour
{
    AudioSource shootAudio;

    public GameObject bulletPrefab;
    public GameObject[] gameObjects;
    public Transform point;
    public GameObject parents;
    private int pivot = 0;
    void Start()
    {
        shootAudio = GetComponent<AudioSource>();

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
        Shoot();
    }
    void Shoot()
    {
        //일시정지 시 조작 불가
        if(GameManager.isPause==false)
        {
            //탄환 발사
            if(Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyUp(KeyCode.Space))
            {
                shootAudio.Play();
                gameObjects[pivot].SetActive(true);
                Rigidbody2D rigid = gameObjects[pivot].GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up*10,ForceMode2D.Impulse);
                gameObjects[pivot].transform.position = transform.position;
                pivot++;
                if (pivot == 20) pivot = 0;
            }
        }
    }
}
