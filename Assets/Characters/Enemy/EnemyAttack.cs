using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float _damage = 40f;

    PlayerHealth _target;

    void Start()
    {
        _target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (_target == null) return;

        _target.TakeDamage(_damage);
    }
}
