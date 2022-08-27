using System.Collections;
using Interfaces;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {

  [SerializeField] private int health;
  [SerializeField] private float speed = 1f;
  [SerializeField] private int damage = 1;
  [SerializeField] private float attackRange = 2f;
  [SerializeField] private float attackCooldown = 4f;
  private Rigidbody2D rb2d;

  private Player player;

  private bool isOnAttackCooldown;

  // Unity Callbacks
  private void Start() {
    this.rb2d = this.GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate() {
    if (this.player) {
      Vector2 movementVector = (Vector2)this.player.transform.position - this.rb2d.position;

      if (movementVector.sqrMagnitude <= this.attackRange * this.attackRange) {
        this.StartAttack();
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

    this.player = col.transform.GetComponent<Player>();
  }

  private void OnTriggerExit2D(Collider2D col) {
    if (!col.CompareTag("Player")) {
      return;
    }

    this.player = null;
  }

  private void OnDrawGizmosSelected() {
    UnityEditor.Handles.DrawWireDisc(this.transform.position, Vector3.forward, this.attackRange);
  }

  // Public methods
  public void TakeDamage(int amount) {
    this.health -= amount;

    if (this.health <= 0) {
      Destroy(this.gameObject);
    }
  }

  // Private methods
  private void StartAttack() {
    if (!this.isOnAttackCooldown) {
      this.StartCoroutine(this.Attack());
    }
  }

  private IEnumerator Attack() {
    this.player.TakeDamage(this.damage);
    this.isOnAttackCooldown = true;

    yield return new WaitForSeconds(this.attackCooldown);
    this.isOnAttackCooldown = false;
  }
}
