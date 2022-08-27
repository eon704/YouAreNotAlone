using Managers;
using UnityEngine;

namespace UI {
  public class MenuUI: MonoBehaviour {
    public void LoadLevel(string scene) {
      LevelManager.LoadScene(scene);
    }

    public void QuitToDesktop() {
      LevelManager.Exit();
    }
  }
}
