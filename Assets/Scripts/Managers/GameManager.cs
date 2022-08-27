using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Managers {
  public class GameManager: MonoBehaviour {
    [SerializeField] private GameUI gameUI;

    public static GameManager Instance;

    public UnityAction OnLevelComplete;
    public UnityAction OnLevelFailed;

    private void Awake() {
      if (Instance != null) {
        Debug.LogWarning("Destroying duplicate instance of GameManager!");
      }
      
      Instance = this;
    }

    public void Start() {
      this.gameUI.Initialize(this);
    }

    public void LevelComplete() {
      this.OnLevelComplete?.Invoke();
    }

    public void LevelFailed() {
      this.OnLevelFailed?.Invoke();
    }
  }
}
