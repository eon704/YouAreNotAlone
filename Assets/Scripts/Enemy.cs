using UnityEngine;

public class Enemy : MonoBehaviour {

  [SerializeField] private float speed = 1f;
  private Rigidbody2D rb2d;

  private Transform player;

  // Start is called before the first frame update
  void Start() {
    this.rb2d = this.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void FixedUpdate() {
    if (this.player) {
      Vector2 movementVector = (Vector2)this.player.position - this.rb2d.position;
      movementVector = movementVector.normalized * (this.speed * Time.fixedDeltaTime);

      this.rb2d.MovePosition(this.rb2d.position + movementVector);
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (!other.CompareTag("Player")) {
      return;
    }

    print("Player in range!");
    this.player = other.transform;
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (!other.CompareTag("Player")) {
      return;
    }

    print("Player escaped!!");
    this.player = null;
  }
}
