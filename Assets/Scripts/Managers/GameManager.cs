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
      if (Instance == null) {
        Instance = this;
      } else {
        Debug.LogWarning("Destroying duplicate instance of a Singleton.");
        Destroy(this.gameObject);
      }
    }

    public void Start() {
      this.gameUI.Initialize(this);
    }

    public void LevelComplete() {
      print("Won!");
      this.OnLevelComplete?.Invoke();
    }

    public void LevelFailed() {
      print("Lost");
      this.OnLevelFailed?.Invoke();
    }
  }
}
