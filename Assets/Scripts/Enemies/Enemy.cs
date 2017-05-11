using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Characters
{
    [Header("Enemy")]
    public Transform target;

    protected NavMeshAgent agent;
    protected bool isAgentActive = true;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        SeektoTarget();
        if (CheckDeath())
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (IsAtTarget())
        {
            Attack();
        }
    }

    protected virtual void Attack() { }

    protected void SeektoTarget()
    {
        if (target != null)
        {
            if (isAgentActive)
            {
                agent.Resume();
                agent.SetDestination(target.position);
            }
            else
            {
                agent.Stop();
            }
        }

    }

    protected bool IsAtTarget()
    {
        if (!agent.hasPath)
            return false;
        return agent.remainingDistance <= agent.stoppingDistance;

    }

}
