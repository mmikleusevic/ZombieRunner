using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _damage = 40f;

    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (_target == null) return;
        
        Debug.Log("bang");

    }
}
