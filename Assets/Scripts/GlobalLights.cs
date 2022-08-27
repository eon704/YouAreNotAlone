using UnityEngine;

public class GlobalLights : MonoBehaviour {

  [SerializeField] private bool isEnabled;

  void Awake() {
    this.gameObject.SetActive(this.isEnabled);
  }
}
