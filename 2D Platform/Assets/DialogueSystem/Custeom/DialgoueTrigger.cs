using DS.ScriptableObjects;
using UnityEngine;

namespace DS
{
    public class DialgoueTrigger : MonoBehaviour
    {
        public DSDialogueSO Dialgoue;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("�÷��̾�� �浹��");
                DialogueManager player = collision.GetComponent<DialogueManager>();
                player.CurrentDialogue = Dialgoue;
            }
        }
    } 
}
