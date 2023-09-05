using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        _hitPoints -= damage;

        Debug.Log(_hitPoints);

        if (_hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
