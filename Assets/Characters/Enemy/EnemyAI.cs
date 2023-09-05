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
        GetComponent<Animator>().SetBool(ATTACK, false);

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
        _navMeshAgent.stoppingDistance = 0f;

        GetComponent<Animator>().SetTrigger(MOVE);
        GetComponent<Animator>().SetBool(ATTACK, false);

        SetPosition(_initialPosition);

        _chasePersistTimer = INITIAL_CHASE_TIME;
    }

    private void Idle()
    {
        GetComponent<Animator>().SetBool(ATTACK, false);
        GetComponent<Animator>().SetTrigger(IDLE);
    }

    private void SetPosition(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }
}
