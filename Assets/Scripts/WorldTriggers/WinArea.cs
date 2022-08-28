using Managers;
using UnityEngine;

namespace WorldTriggers {
  public class WinArea: MonoBehaviour {
    public void TriggerWin() {
      print("Win triggered");
      GameManager.Instance.LevelComplete();
    }
  }
}
