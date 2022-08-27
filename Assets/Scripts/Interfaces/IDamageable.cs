using UnityEngine.Events;

namespace Interfaces {
  public interface IDamageable {
    public int MaxHealth { get; }
    public void TakeDamage(int amount);
    public UnityAction<int> OnHealthChanged { get; set; }
    public UnityAction OnDeath { get; set; }
  }
}
