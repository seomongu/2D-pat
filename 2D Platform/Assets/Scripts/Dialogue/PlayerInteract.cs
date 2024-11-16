using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("대화 시스템")]
    public GameObject DialogueBackGround;

    public bool hasExistNPC = false;
    public NPCText currentNPC;

    // Start is called before the first frame update
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueObject;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GameObject.Find("Canvas/배경화면/NPC 이름").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("Canvas/배경화면/대화").GetComponent<TextMeshProUGUI>();
        dialogueObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        InteractNPC(hasExistNPC);
    }
    public void InteractNPC(bool canSpeak)
    {
        // 플레이어가 e버튼을 눌렀을 때 + NPC가 주변에 있을 때
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {
            EnableDialogue();
        }
    }

    private void EnableDialogue()
    {
        // 대화창이 비활성화 상태에서 활성화 하기
        if (DialogueBackGround.activeInHierarchy)
        {
            DialogueBackGround.SetActive(false);
        }
        else
        {
            TypeText();
        }
    }

    private void TypeText()
    {
        DialogueBackGround.SetActive(true);
        // NPC의 정보를 화면에 출력한다.
        nameText.text = currentNPC.npcName;
        dialogueText.text = currentNPC.dialogues[0];

        // n초 후에 1번을 출력하라.

        // 키보드로 next 버튼을 누를 때 다음 텍스트가 나온다.

    }

    public void CloseText()
    {
        DialogueBackGround.SetActive(false);
    }
}
