using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("대화 시스템")]
    public GameObject DialogueBackGround;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueObject;
    [Space]
    public bool hasExistNPC = false;
    public NPCText currentNPC;
    public float typeSpeed;        // 글자가 한글자씩 출력이 되게 기능, 

    private Queue<String> lines = new Queue<String>();
    private string currentText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // nameText,dialogue 텍스트를 받아와서 실행해주는 컴포넌트 - 게임 창에서 아래 항목을 찾아와라.
        nameText = GameObject.Find("Canvas/Dialouge Background/NPC_Name").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("Canvas/Dialouge Background/Dialogue_Text").GetComponent<TextMeshProUGUI>();

    }


    // Update is called once per frame
    void Update()
    {
        InteractNPC(hasExistNPC);
    }

    public void InteractNPC(bool canSpeak)
    {
        // 플레이어가 e버튼을 눌렀을 때 + NPC 주변에 있을 때
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {
            EnableDialogue();
        }
    }

    private void EnableDialogue()
    {
        // 대화창 비활성화되어 있는 상태 -> 활성화

        animator.Play("Show");
        TypeText();
    }

    public void GetDialogueByNPC(NPCText npc)
    {
        foreach (var line in npc.dialogues)
        {
            lines.Enqueue(line);
        }
    }

    private void TypeText()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueBackGround.SetActive(true);
        // npc의 정보를 화면에 출력한다.
        nameText.text = currentNPC.npcName;
        currentText = lines.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentText));
    }

    IEnumerator TypeSentence(string currentLine)
    {
        dialogueText.text = "";
        foreach(char letter in currentLine)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

    }

    private void EndDialogue()
    {
        lines.Clear();
        animator.Play("Hide");
    }

    public void CloseText()
    {
        lines.Clear();
        animator.Play("Hide");
    }
}
