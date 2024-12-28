using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float moveSpeed = 2f;  // 이동 속도
    public float moveRange = 5f;  // 이동 범위
    private float targetPosX;     // 목표 X 위치
    private SpriteRenderer spriteRenderer; // SpriteRenderer 컴포넌트

    // true 정방향, false 뒤집다.
    public bool flip; 

    void Start()
    {
        // SpriteRenderer 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 초기 목표 X 위치 설정
        SetRandomTargetPos();
    }

    void Update()
    {
        // 목표 위치로 부드럽게 이동
        float newPosX = Mathf.Lerp(transform.position.x, targetPosX, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);

        // 목표 위치에 도달하면 새로운 랜덤 목표 위치로 설정
        if (Mathf.Abs(transform.position.x - targetPosX) < 0.1f)
        {
            SetRandomTargetPos();  // 새로운 목표 위치 설정
        }

        // 이동 방향에 따라 좌우 반전
        if (newPosX < transform.position.x)
        {
            spriteRenderer.flipX = true; // 왼쪽으로 이동 시 반전
        }
        else if (newPosX > transform.position.x)
        {
            spriteRenderer.flipX = false; // 오른쪽으로 이동 시 반전 해제
        }

        if(flip)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    // 랜덤한 목표 위치를 설정하는 함수
    private void SetRandomTargetPos()
    {
        float randomValue = Random.Range(-moveRange, moveRange);

        targetPosX = transform.position.x + randomValue; // 현재 위치에서 랜덤으로 목표 설정

        if(randomValue < 0)
        {
            flip = false;
        }
        else
        {
            flip = true;
        }
    }
}
