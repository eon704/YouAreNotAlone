using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Managers {
  public class GameManager: MonoBehaviour {
    [SerializeField] private GameUI gameUI;

    public static GameManager Instance;

    public UnityAction OnLevelComplete;
    public UnityAction OnLevelFailed;
    public UnityAction OnGamePaused;
    public UnityAction OnGameUnpaused;

    private bool isPaused;

    private void Awake() {
      if (Instance != null) {
        Debug.LogWarning("Destroying duplicate instance of GameManager!");
      }

      Instance = this;
    }

    private void Start() {
      this.isPaused = false;
      this.gameUI.Initialize(this);
    }

    private void Update() {
      if (Input.GetKeyDown(KeyCode.Escape)) {
        this.TogglePausedState();
      }
    }

    public void LevelComplete() {
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
  }
}
