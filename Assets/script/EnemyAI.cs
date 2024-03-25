
using System;
using System.Collections.Generic;
using script.игрок;
using UnityEngine.AI;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyAI : MonoBehaviour
{
    //переменные
    private bool _isPlayerNoticed;

    private NavMeshAgent _navMeshAgent;
    
    private Animator anim; 

    [SerializeField] private List<Transform> patrolPoints;

    [SerializeField] private PlayerController player;

    [SerializeField] private float viewAngle;

    public float HP;

    private PlayerProgress _playerProgress;

    [SerializeField] private float damage;
    
    
    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        
        anim = GetComponentInChildren<Animator>();

        _playerProgress = FindObjectOfType<PlayerProgress>(true);
        player = FindObjectOfType<PlayerController>(true);

    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        PatrolUpdate();

        if (!player)
        {
            return;
        }

        NoticePlayerUpdate();
        
        ChaseUpdate();
        
        AttackUpdate();
        
        if (0 >= HP)
        {
            Destroy(gameObject);
        }
    }
    //взгляд игрока
    private  void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            _isPlayerNoticed = false;
            anim.SetBool("isPlayerNoticed", false);
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true; 
                    
                    anim.SetBool("isPlayerNoticed", true);
                } 
            }
        }
    }
    //патрулирование
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed) 
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                player.GetComponent<PlayerHp>().DealDamag(damage * Time.deltaTime);
            }
        }
    }
    public void Damage(float damage)
    {
        _playerProgress.AddExperience(damage);
        HP -= damage;
    }
}
