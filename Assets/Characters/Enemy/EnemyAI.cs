using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _chaseRange = 10f;

    NavMeshAgent _navMeshAgent;
    Vector3 _initialPosition;
    float _distanceToTarget = Mathf.Infinity;
    float _chasePersistTimer = INITIAL_CHASE_TIME;
    bool _isChasing = false;

    static float INITIAL_CHASE_TIME = 5f;
    static string IDLE = "Idle";
    static string MOVE = "Move";
    static string ATTACK = "Attack";

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _initialPosition = transform.position;
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
    }

    private void EngageTarget()
    {
        if (_distanceToTarget > _navMeshAgent.stoppingDistance)
        {
            Chase();
        }

        if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void PersistChase()
    {
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
        GetComponent<Animator>().SetTrigger(MOVE);

        _isChasing = true;


        if (_chasePersistTimer < INITIAL_CHASE_TIME)
        {
            _chasePersistTimer = INITIAL_CHASE_TIME;
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool(ATTACK, true);
    }

    private void ReturnToInitialPosition()
    {
        GetComponent<Animator>().SetTrigger(IDLE);
        GetComponent<Animator>().SetBool(ATTACK, false);

        SetPosition(_initialPosition);

        _chasePersistTimer = INITIAL_CHASE_TIME;
    }

    private void SetPosition(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }
}
