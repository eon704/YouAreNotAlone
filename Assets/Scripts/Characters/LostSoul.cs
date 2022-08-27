using Characters;
using UnityEngine;

public class LostSoul : MonoBehaviour {

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      other.GetComponent<Player>().AcceptNewGroupMember();
      // col.enabled = false;
      Destroy(this.gameObject);
    }
  }
}
