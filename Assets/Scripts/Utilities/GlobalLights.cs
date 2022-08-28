using UnityEngine;

public class GlobalLights : MonoBehaviour {

  [SerializeField] private bool isEnabled;

  void Awake() {
    #if UNITY_EDITOR
    this.gameObject.SetActive(this.isEnabled);
    #else
    this.gameObject.SetActive(false);
    #endif
  }
}
