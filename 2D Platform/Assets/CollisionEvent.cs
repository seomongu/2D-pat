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
            // üũ ����Ʈ�� ������� Ȯ���ϴ� ���
            // Ư�� ��ġ�� ������ �ȴ�.
        }
    }
}
