using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("��ȭ �ý���")]
    public GameObject DialogueBackGround;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueObject;
    [Space]
    public bool hasExistNPC = false;
    public NPCText currentNPC;
    public float typeSpeed;        // ���ڰ� �ѱ��ھ� ����� �ǰ� ���, 

    private Queue<String> lines = new Queue<String>();
    private string currentText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // nameText,dialogue �ؽ�Ʈ�� �޾ƿͼ� �������ִ� ������Ʈ - ���� â���� �Ʒ� �׸��� ã�ƿͶ�.
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
        // �÷��̾ e��ư�� ������ �� + NPC �ֺ��� ���� ��
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {
            EnableDialogue();
        }
    }

    private void EnableDialogue()
    {
        // ��ȭâ ��Ȱ��ȭ�Ǿ� �ִ� ���� -> Ȱ��ȭ

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
        // npc�� ������ ȭ�鿡 ����Ѵ�.
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
