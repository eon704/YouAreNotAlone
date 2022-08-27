using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
  public class LevelManager: MonoBehaviour {
    public void LoadScene(string sceneName) {
      SceneManager.LoadScene(sceneName);
    }

    public void Exit() {
      #if UNITY_EDITOR
        print("Application Quit was called.");
      #endif
      Application.Quit();
    }
  }
}
