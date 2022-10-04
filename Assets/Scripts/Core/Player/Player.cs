using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _lives;

    public void ApplyDamage(int damage)
    {
        _lives -= damage;

        if (_lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
