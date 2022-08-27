using Managers;
using UnityEngine;

namespace WorldTriggers {
  public class WinArea: MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D col) {
      if (col.CompareTag("Player")) {
        GameManager.Instance.LevelComplete();
      }
    }
  }
}
