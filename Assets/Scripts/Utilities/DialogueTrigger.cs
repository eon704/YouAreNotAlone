using Managers;
using Model;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities {
  public class DialogueTrigger: MonoBehaviour {
    [SerializeField] private Dialogue dialogue;

    // ReSharper disable once MemberCanBePrivate.Global
    public void TriggerDialogue() {
      DialogueManager.Instance.StartDialogue(this.dialogue);
    }

    public void SetOnComplete(UnityEvent onComplete) {
      this.dialogue.OnComplete = onComplete;
    }

    private void OnTriggerEnter2D(Collider2D col) {
      if (col.CompareTag("Player")) {
        this.TriggerDialogue();
      }
    }
  }
}
