using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _maxHitPoints = 100f;
    float _currenthitPoints;

    private void Start()
    {
        _currenthitPoints = _maxHitPoints;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage(EnemyAI.ON_DAMAGE_RECEIVED_METHOD_NAME);

        _currenthitPoints -= damage;

        if (_currenthitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ResetHealth()
    {
        _currenthitPoints = _maxHitPoints;
    }
}
