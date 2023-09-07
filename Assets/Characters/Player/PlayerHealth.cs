using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        _hitPoints -= damage;

        if (_hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
