using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoints : MonoBehaviour
{
    public Transform SavePosition;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevivePlayer()
    {
        player.position = SavePosition.position;
    }

    public void SavePoint(Transform savePos)
    {
        savePos.position = SavePosition.position; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // 현재 지점으로 세이브 포인트 저장


        }

    }
}
