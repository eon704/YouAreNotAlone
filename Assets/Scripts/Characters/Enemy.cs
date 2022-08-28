using System.Collections;
using Interfaces;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Characters {
  public class Enemy : MonoBehaviour, IDamageable {

    [SerializeField] private int health;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 4f;

    public int MaxHealth => this.health;
    public UnityAction<int> OnHealthChanged { get; set; }
    public UnityAction OnDeath { get; set; }

    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    private Player player;
    private bool isOnAttackCooldown;

    // Unity Callbacks
    private void Start() {
      this.rb2d = this.GetComponent<Rigidbody2D>();
      this.audioSource = this.GetComponent<AudioSource>();
      GameUI.Instance.InstantiateNewHealthBar(this, this.transform);
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

    // private void OnTriggerExit2D(Collider2D col) {
    //   if (!col.CompareTag("Player")) {
    //     return;
    //   }
    //
    //   this.player = null;
    //   this.rb2d.velocity = Vector2.zero;
    // }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
      UnityEditor.Handles.DrawWireDisc(this.transform.position, Vector3.forward, this.attackRange);
    }
    #endif

    // Public methods
    public void TakeDamage(int amount) {
      this.health -= amount;
      this.OnHealthChanged?.Invoke(this.health);

      if (this.health <= 0) {
        this.OnDeath?.Invoke();
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
      this.audioSource.Play();

      yield return new WaitForSeconds(this.attackCooldown);
      this.isOnAttackCooldown = false;
    }
  }
}
