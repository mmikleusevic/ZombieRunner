using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float _damage = 40f;

    PlayerHealth _target;

    void Start()
    {
        _target = FindFirstObjectByType<PlayerHealth>();
    }

    public async Task AttackHitEvent()
    {
        if (_target == null) return;

        _target.TakeDamage(_damage);
        await _target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
