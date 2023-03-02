using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newscroll : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float scrollRange = 9f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;

    private void Update()
    {
        // 배경 스크롤
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 배경 위치 재설정
        if(transform.position.y <= -scrollRange)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }    
    }
}
