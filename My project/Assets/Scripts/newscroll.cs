using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newscroll : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float scrollRange = 9.9f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;

    private void Update()
    {
        // Background move to moveDirection, speed = moveSpeed;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;


        // 배경이 설정된 범위를 벗어나면 위치 재설정
        if(transform.position.y <= -scrollRange)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }    
    }
}