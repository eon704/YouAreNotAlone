using Managers;
using Model;
using UnityEngine;

namespace Utilities {
  public class DialogueTrigger: MonoBehaviour {
    public Dialogue dialogue;

    public void TriggerDialogue() {
      DialogueManager.Instance.StartDialogue(this.dialogue);
    }

    private void OnTriggerEnter2D(Collider2D col) {
      if (col.CompareTag("Player")) {
        this.TriggerDialogue();
      }
    }
  }
}
