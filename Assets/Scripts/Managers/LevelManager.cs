using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
  public static class LevelManager {
    public static void LoadScene(string sceneName) {
      SceneManager.LoadScene(sceneName);
    }

    public static void Exit() {
      #if UNITY_EDITOR
        Debug.Log("Application Quit was called.");
      #endif
      Application.Quit();
    }
  }
}
