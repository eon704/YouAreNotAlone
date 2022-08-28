using Characters;
using UI;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Managers {
  public class GameManager: MonoBehaviour {
    [SerializeField] private GameUI gameUI;
    [SerializeField] private DialogueTrigger levelStartDialogueTrigger;

    public static GameManager Instance;

    public UnityAction OnLevelComplete;
    public UnityAction OnLevelFailed;
    public UnityAction OnGamePaused;
    public UnityAction OnGameUnpaused;
    public UnityAction OnDialogueStarted;
    public UnityAction OnDialogueEnded;

    private bool isPaused;
    private Player player;

    private void Awake() {
      if (Instance != null) {
        Debug.LogWarning("Destroying duplicate instance of GameManager!");
      }

      this.OnDialogueStarted += this.OnDialogueStart;
      this.OnDialogueEnded += this.OnDialogueEnd;

      Instance = this;
    }

    private void Start() {
      this.isPaused = false;
      this.gameUI.Initialize(this);
      this.player = FindObjectOfType<Player>();
      this.player.BlockInput();
      this.levelStartDialogueTrigger.TriggerDialogue();
    }

    private void Update() {
      if (Input.GetKeyDown(KeyCode.Escape)) {
        this.TogglePausedState();
      }
    }

    public void LevelComplete() {
      this.player.BlockInput();
      this.OnLevelComplete?.Invoke();
    }

    public void LevelFailed() {
      this.OnLevelFailed?.Invoke();
    }

    public void UnPauseGame() {
      this.isPaused = false;
      Time.timeScale = 1f;
      this.OnGameUnpaused?.Invoke();
    }

    private void TogglePausedState() {
      if (this.isPaused) {
        this.UnPauseGame();
      } else {
        this.PauseGame();
      }
    }

    private void PauseGame() {
      this.isPaused = true;
      Time.timeScale = 0f;
      this.OnGamePaused?.Invoke();
    }

    private void OnDialogueStart() {
      this.player.BlockInput();
    }

    private void OnDialogueEnd() {
      this.player.UnblockInput();
    }
  }
}
