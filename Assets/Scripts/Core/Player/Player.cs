using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _lives;

    public event UnityAction<int> LivesChanged;
    public event UnityAction Died;

    private void Start()
    {
        LivesChanged?.Invoke(_lives);
    }

    public void ApplyDamage(int damage)
    {
        _lives -= damage;
        LivesChanged?.Invoke(_lives);

        if (_lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
