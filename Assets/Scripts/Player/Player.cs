using UnityEngine;

public class Player : MonoBehaviour {

  [SerializeField] private int health;
  [SerializeField] private float speed = 1f;

  private Rigidbody2D rb2d;

  void Start() {
    this.rb2d = this.GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    Vector2 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    if (input.sqrMagnitude > 1f) {
      input = input.normalized;
    }

    Vector2 move = input * (this.speed * Time.fixedDeltaTime);
    this.rb2d.MovePosition(move + this.rb2d.position);
  }

  public void TakeDamage(int amount) {
    this.health -= amount;

    if (this.health <= 0) {
      Debug.Log("You have died");
    }
  }
}

