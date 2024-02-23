
using System;
using System.Collections.Generic;
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

    [SerializeField] private int HP;

    [SerializeField] private int damagPlayer;
    
    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        
        anim = GetComponentInChildren<Animator>();
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (0 >= HP)
        {
            Destroy(gameObject);
        }
        
        NoticePlayerUpdate();

        ChaseUpdate();
        
        PatrolUpdate();
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
            if (_navMeshAgent.remainingDistance == 0)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bomb")
        {
            HP = HP - damagPlayer;
        }
    }
}
