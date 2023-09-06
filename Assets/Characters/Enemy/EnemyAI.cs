using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _chaseRange = 10f;

    NavMeshAgent _navMeshAgent;
    Animator _animator;
    Vector3 _initialPosition;

    float _distanceToTarget = Mathf.Infinity;
    float _chasePersistTimer = INITIAL_CHASE_TIME;
    float _turnSpeed = 5;
    bool _isChasing = false;

    static string IDLE = "Idle";
    static string MOVE = "Move";
    static string ATTACK = "Attack";
    static float INITIAL_CHASE_TIME = 5f;
    public static string ON_DAMAGE_RECEIVED_METHOD_NAME = nameof(OnDamageReceived);


    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _initialPosition = transform.position;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }

    public void OnDamageReceived()
    {
        bool isAttacking = GetComponent<Animator>().GetBool(ATTACK);

        if (!isAttacking)
        {
            _isChasing = true;
        }
    }

    private void ChasePlayer()
    {
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);

        if (_distanceToTarget <= _chaseRange)
        {
            EngageTarget();
        }
        else if (_isChasing)
        {
            PersistChase();
        }
        else if (!_isChasing && Vector3.Distance(transform.position, _initialPosition) > 0.1f)
        {
            ReturnToInitialPosition();
        }
        else if(!_isChasing)
        {
            Idle();
        }
    }

    private void EngageTarget()
    {
        _navMeshAgent.stoppingDistance = 4f;

        if (_distanceToTarget > _navMeshAgent.stoppingDistance)
        {
            Chase();
        }

        if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
        {
            FaceTarget();
            AttackTarget();
        }
    }

    private void PersistChase()
    {
        bool isMoving = _animator.GetBool(MOVE);

        if (!isMoving)
        {
            _animator.SetTrigger(MOVE);
        }

        if (_chasePersistTimer > 0)
        {
            SetPosition(_target.position);
            _chasePersistTimer -= Time.deltaTime;
        }
        else
        {
            _isChasing = false;
        }
    }

    private void Chase()
    {
        SetPosition(_target.position);

        _animator.SetTrigger(MOVE);
        _animator.SetBool(ATTACK, false);

        _isChasing = true;

        if (_chasePersistTimer < INITIAL_CHASE_TIME)
        {
            _chasePersistTimer = INITIAL_CHASE_TIME;
        }
    }

    private void AttackTarget()
    {
        _animator.SetBool(ATTACK, true);
    }

    private void ReturnToInitialPosition()
    {
        _navMeshAgent.stoppingDistance = 0f;

        _animator.SetTrigger(MOVE);
        _animator.SetBool(ATTACK, false);

        SetPosition(_initialPosition);

        _chasePersistTimer = INITIAL_CHASE_TIME;
    }

    private void Idle()
    {
        _animator.SetBool(ATTACK, false);
        _animator.SetTrigger(IDLE);

        GetComponent<EnemyHealth>().ResetHealth();
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    private void SetPosition(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }
}
