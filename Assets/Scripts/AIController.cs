using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class WayPoints
{
    public List<Transform> wayPoints;
}

public class AIController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;

    public List<WayPoints> wayPoints;
    public AIType type;

    public Transform target;

    public float lookRadius;
    public int currentWayPoint;
    public enum AIType
    {
        Idle,
        Patrol,
        Run,
        Attack
    };

    public List<Transform> points;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        points = wayPoints[GameManager.Instance.LevelSelected].wayPoints;
    }

    public void Update()
    {
        var distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
    }

    public void LookingPlayer(Vector3 player)
    {
        agent.SetDestination(player);
        var distance = Vector3.Distance(transform.position, player);
        if (distance <= 0.3f)
        {

        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    }
    public void Move(float speed)
    {
        agent.isStopped = false;
        agent.speed = speed;
    }
}
