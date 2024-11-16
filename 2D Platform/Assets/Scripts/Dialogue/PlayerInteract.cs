using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("��ȭ �ý���")]
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
        nameText = GameObject.Find("Canvas/���ȭ��/NPC �̸�").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("Canvas/���ȭ��/��ȭ").GetComponent<TextMeshProUGUI>();
        dialogueObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        InteractNPC(hasExistNPC);
    }
    public void InteractNPC(bool canSpeak)
    {
        // �÷��̾ e��ư�� ������ �� + NPC�� �ֺ��� ���� ��
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {
            EnableDialogue();
        }
    }

    private void EnableDialogue()
    {
        // ��ȭâ�� ��Ȱ��ȭ ���¿��� Ȱ��ȭ �ϱ�
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
        // NPC�� ������ ȭ�鿡 ����Ѵ�.
        nameText.text = currentNPC.npcName;
        dialogueText.text = currentNPC.dialogues[0];

        // n�� �Ŀ� 1���� ����϶�.

        // Ű����� next ��ư�� ���� �� ���� �ؽ�Ʈ�� ���´�.

    }

    public void CloseText()
    {
        DialogueBackGround.SetActive(false);
    }
}
