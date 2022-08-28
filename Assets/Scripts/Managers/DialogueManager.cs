using System.Collections;
using System.Collections.Generic;
using Model;
using TMPro;
using UnityEngine;

namespace Managers {
  public class DialogueManager: MonoBehaviour {
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text sentenceText;

    public static DialogueManager Instance;

    private Queue<string> sentences;
    private Animator animator;

    private static readonly int Hide = Animator.StringToHash("Hide");
    private static readonly int Show = Animator.StringToHash("Show");

    private void Awake() {
      if (Instance == null) {
        Instance = this;
      } else {
        Debug.LogWarning("Deleting duplication DialogueManager Instance");
        Destroy(this.gameObject);
      }
    }

    private void Start() {
      this.sentences = new Queue<string>();
      this.animator = this.GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue) {
      Debug.Log("Starting conversation with " + dialogue.name);

      this.sentences.Clear();

      this.nameText.text = dialogue.name;
      foreach (string sentence in dialogue.sentences) {
        this.sentences.Enqueue(sentence);
      }

      this.animator.SetTrigger(Show);
      this.DisplayNextSentence();
    }

    public void DisplayNextSentence() {
      if (this.sentences.Count <= 0) {
        this.EndDialogue();
        return;
      }

      string sentence = this.sentences.Dequeue();
      this.StopAllCoroutines();
      this.StartCoroutine(this.TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence) {
      this.sentenceText.text = "";

      foreach (char letter in sentence) {
        this.sentenceText.text += letter;
        yield return null;
      }
    }

    private void EndDialogue() {
      this.animator.SetTrigger(Hide);
    }
  }
}