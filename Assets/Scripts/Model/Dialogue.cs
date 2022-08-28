using UnityEngine;
using UnityEngine.Events;

namespace Model {

  [System.Serializable]
  public class Dialogue {
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

    public UnityEvent OnComplete;
  }
}
