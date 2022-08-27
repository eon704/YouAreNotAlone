using UnityEngine;

namespace UI {
  public class PlayerHealth: MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private Transform healthIconContainer;
    [SerializeField] private GameObject healthIconPrefab;

    private void Start() {
      this.player.OnHealthChanged += this.OnHealthChange;
    }

    private void OnHealthChange(int newHealth) {
      foreach (Transform child in this.healthIconContainer) {
        Destroy(child.gameObject);
      }

      for (int i = 0; i < newHealth; i++) {
        Instantiate(this.healthIconPrefab, this.healthIconContainer);
      }
    }
  }
}
