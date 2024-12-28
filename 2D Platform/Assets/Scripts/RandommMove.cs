using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float moveSpeed = 2f;  // �̵� �ӵ�
    public float moveRange = 5f;  // �̵� ����
    private float targetPosX;     // ��ǥ X ��ġ
    private SpriteRenderer spriteRenderer; // SpriteRenderer ������Ʈ

    // true ������, false ������.
    public bool flip; 

    void Start()
    {
        // SpriteRenderer ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>();

        // �ʱ� ��ǥ X ��ġ ����
        SetRandomTargetPos();
    }

    void Update()
    {
        // ��ǥ ��ġ�� �ε巴�� �̵�
        float newPosX = Mathf.Lerp(transform.position.x, targetPosX, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);

        // ��ǥ ��ġ�� �����ϸ� ���ο� ���� ��ǥ ��ġ�� ����
        if (Mathf.Abs(transform.position.x - targetPosX) < 0.1f)
        {
            SetRandomTargetPos();  // ���ο� ��ǥ ��ġ ����
        }

        // �̵� ���⿡ ���� �¿� ����
        if (newPosX < transform.position.x)
        {
            spriteRenderer.flipX = true; // �������� �̵� �� ����
        }
        else if (newPosX > transform.position.x)
        {
            spriteRenderer.flipX = false; // ���������� �̵� �� ���� ����
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

    // ������ ��ǥ ��ġ�� �����ϴ� �Լ�
    private void SetRandomTargetPos()
    {
        float randomValue = Random.Range(-moveRange, moveRange);

        targetPosX = transform.position.x + randomValue; // ���� ��ġ���� �������� ��ǥ ����

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
