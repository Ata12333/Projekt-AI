using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAndChase : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float targetRadius = 0.1f;

    private int indexOfTarget;
    private Vector3 targetPoint;

    private State state = State.PatrolState;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        indexOfTarget = -1;
        NextTarget();
        LookAtTarget();
    }

    void Update()
    {
        if(state == State.PatrolState)
        {
            Patrol();
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
        if ((transform.position - targetPoint).magnitude < targetRadius)
        {
            NextTarget();
            LookAtTarget();
        }

        Vector3 velocity = targetPoint - transform.position;
        velocity.Normalize();
        velocity *= moveSpeed * Time.deltaTime;
        controller.Move(velocity);
    }

    enum State
    {
        PatrolState,
        ChaseState
    }
}
