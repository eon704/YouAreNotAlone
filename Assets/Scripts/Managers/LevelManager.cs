using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
  public static class LevelManager {
    private static string CurrentSceneName => SceneManager.GetActiveScene().name;
    public static void ReloadScene() {
      Time.timeScale = 1f;
      SceneManager.LoadScene(CurrentSceneName);
    }

    public static void LoadScene(string sceneName) {
      Time.timeScale = 1f;
      SceneManager.LoadScene(sceneName);
    }

    public static void Exit() {
      #if UNITY_EDITOR
        Debug.Log("Application Quit was called.");
      #endif
      Application.Quit();
    }

    public static void LoadNextLevel() {
      switch (CurrentSceneName) {
        case "Level 1":
          LoadScene("Level 2");
          break;
        case "Level 2":
          LoadScene("Level 3");
          break;
        case "Level 3":
          LoadScene("MainMenu");
          break;
        default:
          Debug.LogWarning("UNHANDLED NEXT LEVEL LOAD CASE");
          break;
      }
    }
  }
}
