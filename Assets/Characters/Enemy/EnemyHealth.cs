using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _maxHitPoints = 100f;
    float _currenthitPoints;

    bool isDead = false;

    static string DIE = "Die";

    private void Start()
    {
        _currenthitPoints = _maxHitPoints;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage(EnemyAI.ON_DAMAGE_RECEIVED_METHOD_NAME);

        _currenthitPoints -= damage;

        if (_currenthitPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger(DIE);
        Destroy(gameObject, 30);
    }

    public void ResetHealth()
    {
        _currenthitPoints = _maxHitPoints;
    }
}
