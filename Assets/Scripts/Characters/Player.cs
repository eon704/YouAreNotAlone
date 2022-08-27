using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour {
  [SerializeField] private float speed = 1f;
  [SerializeField] private int damage = 1;
  [SerializeField] private float attackRange = 2f;
  [SerializeField] private float attackCooldown = 4f;

  public UnityAction<int> OnHealthChanged;

  private Rigidbody2D rb2d;
  private Light2D soulLight;
  private IDamageable target;
  private bool isOnAttackCooldown;

  private readonly RaycastHit2D[] targetsBuffer = new RaycastHit2D[20];

  private int Health {
    get => this.groupMembersCount;
    set {
      this.groupMembersCount = value;
      this.soulLight.pointLightOuterRadius = 6 + this.groupMembersCount;
      this.OnHealthChanged?.Invoke(this.groupMembersCount);
    }
  }

  private int groupMembersCount = 1;

  #region Unity Callbacks
  private void Start() {
    this.rb2d = this.GetComponent<Rigidbody2D>();
    this.soulLight = this.GetComponentInChildren<Light2D>();
    this.Health = 1;
  }

  private void Update() {
    if (Input.GetMouseButtonDown(0)) {
      this.StartAttack();
    }
  }

  private void FixedUpdate() {
    Vector2 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    if (input.sqrMagnitude > 1f) {
      input = input.normalized;
    }

    Vector2 move = input * (this.speed * Time.fixedDeltaTime);
    this.rb2d.MovePosition(move + this.rb2d.position);
  }

  private void OnDrawGizmosSelected() {
    UnityEditor.Handles.DrawWireDisc(this.transform.position, Vector3.forward, this.attackRange);
  }

  #endregion

  #region Public methods

  public void TakeDamage(int amount) {
    this.Health -= amount;

    if (this.Health <= 0) {
      Debug.Log("You have died");
    }
  }

  public void AcceptNewGroupMember() {
    this.Health++;
  }

  #endregion

  #region private methods

  private void StartAttack() {
    this.GetTarget();
    if (this.target != null && !this.isOnAttackCooldown) {
      this.StartCoroutine(this.Attack());
    }
  }

  private IEnumerator Attack() {
    this.target.TakeDamage(this.damage);
    this.isOnAttackCooldown = true;

    yield return new WaitForSeconds(this.attackCooldown);
    this.isOnAttackCooldown = false;
  }

  private void GetTarget() {
    int targetsFound = Physics2D.CircleCastNonAlloc(this.transform.position,
                                                    this.attackRange,
                                                    Vector2.zero,
                                                    this.targetsBuffer,
                                                    0f,
                                                    LayerMask.GetMask("Enemy"));
    if (targetsFound <= 0) {
      this.target = null;
      return;
    }

    for (int i = 0; i < targetsFound; i++) {
      RaycastHit2D hit = this.targetsBuffer[i];
      if (hit.transform.gameObject.GetComponent<IDamageable>() == null) {
        Debug.LogWarning($"Target {hit.transform.name} is not IDamageable, check the assigned layers");
      }
    }

    int randomIndex = Random.Range(0, targetsFound);
    this.target = this.targetsBuffer[randomIndex].transform.GetComponent<IDamageable>();
  }
  #endregion
}

