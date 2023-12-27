using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private const int MinHealth = 0;
    private int _currentHealth;

    public event UnityAction<Color> Damaged;
    public event UnityAction<Color> Recovered;

    private void Start()
    {
        _currentHealth = _health;
    }
   
    public void ApplyDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, MinHealth, _health);

        Damaged!.Invoke(Color.red);

        if (_currentHealth <= MinHealth)
            Die();
    }

    public void ApplyHaelth(int health)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + health, MinHealth, _health);

        Recovered!.Invoke(Color.green);
    }

    private void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
    }
}