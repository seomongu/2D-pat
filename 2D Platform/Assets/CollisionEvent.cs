using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    public Transform respawnPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // 체크 포인트가 어디인지 확인하는 기능
            // 특정 위치에 리스폰 된다.
        }
    }
}
