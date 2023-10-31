using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAndChase : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float targetRadius = 0.1f;
    [SerializeField] private float visionRange = 10;
    [SerializeField] private float visionConeAngle = 30;
    [SerializeField] private float HearingRange = 5;

    private int indexOfTarget;
    private Vector3 targetPoint;
    private State state = State.PatrolState;
    private CharacterController controller;
    Animator animator;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        controller = GetComponent<CharacterController>();
        indexOfTarget = -1;
        NextTarget();
        LookAtTarget();
        agent.SetDestination(targetPoint);
    }

    float GetDistanceToPlayer()
    {
        return
            (player.position - transform.position)
            .magnitude;
    }
    
        float GetAngleToPlayer()
    {
        Vector3 directionToPlayer =
            (player.position - transform.position)
            .normalized;
        return Vector3.Angle(transform.forward, directionToPlayer);
    }

        bool SightLineObstructed()
    {
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        Ray ray = new Ray(
            transform.position,
            vectorToPlayer);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, vectorToPlayer.magnitude))
        {
            GameObject obj = hitInfo.collider.gameObject;
            return obj != player.gameObject;
        }
        return false;
    }

    bool CanSeePlayer()
    {
        if (GetDistanceToPlayer() < visionRange)
        {
            if (GetAngleToPlayer() < visionConeAngle)
            {
                if (!SightLineObstructed())
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool CanHearYou()
    {
        if (GetDistanceToPlayer() < HearingRange)
        {    
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if(state == State.PatrolState)
        {
            Patrol();
        }
        if(state == State.ChaseState)
        {
            Chase();
        }
    }

    void NextTarget()
    {
        indexOfTarget = (indexOfTarget + 1) % points.Length;
        targetPoint = points[indexOfTarget].position;
        targetPoint.y = transform.position.y;
    }

    void LookAtTarget()
    {
        Vector3 lookAt = targetPoint;
        lookAt.y = transform.position.y;

        Vector3 lookDir = (lookAt - transform.position).normalized;
        transform.forward = lookDir;
    }

    void Patrol()
    {
        Debug.Log("Target point: " + points[indexOfTarget].name);
        if (CanSeePlayer() || CanHearYou())
        {
            state = State.ChaseState;
            GetComponent<AudioSource>().Play();
            return;
        }

        if ((targetPoint-transform.position).magnitude < agent.radius)
        {
            Debug.Log("Switching point");
            NextTarget();
            LookAtTarget();
        }
        agent.SetDestination(targetPoint);
        // Vector3 velocity = targetPoint - transform.position;
        // velocity.y = 0;
        // velocity.Normalize();
        // velocity *= moveSpeed * Time.deltaTime;
        // controller.Move(velocity);
        animator.SetBool("running", false);

    }
    void Chase()
    {
        if(!CanSeePlayer() && !CanHearYou())
        {
            state = State.PatrolState;
            NextTarget();
            LookAtTarget();
            return;
        }
        LookAtTarget();
        agent.SetDestination(targetPoint);
        targetPoint = player.transform.position;
        Vector3 velocity = targetPoint - transform.position;
        velocity.y = 0;
        velocity.Normalize();
        velocity *= moveSpeed * Time.deltaTime;
        controller.Move(velocity);
        animator.SetBool("running", true);

    }

    enum State
    {
        PatrolState,
        ChaseState,
    }
}
