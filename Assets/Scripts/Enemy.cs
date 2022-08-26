using UnityEngine;

public class Enemy : MonoBehaviour {

  [SerializeField] private float speed = 1f;
  [SerializeField] private float attackRange = 2f;
  private Rigidbody2D rb2d;

  private Transform player;

  private void Start() {
    this.rb2d = this.GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate() {
    if (this.player) {
      Vector2 movementVector = (Vector2)this.player.position - this.rb2d.position;

      if (movementVector.sqrMagnitude <= this.attackRange * this.attackRange) {
        Debug.LogError("Attacking");
      } else {
        movementVector = movementVector.normalized * (this.speed * Time.fixedDeltaTime);
        this.rb2d.MovePosition(this.rb2d.position + movementVector);
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D col) {
    if (!col.CompareTag("Player")) {
      return;
    }

    print("Player found!");
    this.player = col.transform;
  }

  private void OnTriggerExit2D(Collider2D col) {
    if (!col.CompareTag("Player")) {
      return;
    }

    print("Player escaped!");
    this.player = null;
  }

  private void OnDrawGizmosSelected() {
    UnityEditor.Handles.DrawWireDisc(this.transform.position, Vector3.forward, this.attackRange);
  }
}
