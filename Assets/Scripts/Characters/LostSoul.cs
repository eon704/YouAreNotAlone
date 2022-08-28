using Managers;
using UnityEngine;

namespace Characters {
  public class LostSoul : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        other.GetComponent<Player>().AcceptNewGroupMember();
        MusicManager.Instance.PlayLostSoulFound();
        Destroy(this.gameObject);
      }
    }
  }
}
