using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PatrolState : MonoBehaviour, IFSMState
{
    public Transform Destination;
    private SightLine ThisSightLine;
    public float MovementSpeed = 1.5f;
    public float Acceleration = 2.0f;
    public float AngularSpeed = 360.0f;
    public string AnimationRunParamName = "Run";
    public FSMStateType StateName { get { return FSMStateType.Patrol; } }
    private NavMeshAgent ThisAgent;
    private Animator ThisAnimator;

    public void DoAction() {
        ThisAgent.SetDestination(Destination.position);
    }

    public FSMStateType ShouldTransitionToState() {
        if (ThisSightLine.IsTargetInSightLine) {
            return FSMStateType.Chase;
        }

        return StateName;
    }

    private void Awake() {
        ThisAgent = GetComponent<NavMeshAgent>();
        ThisSightLine = GetComponent<SightLine>();
        ThisAnimator = GetComponent<Animator>();
    }

    public void OnEnter() {
        ThisAgent.isStopped = false;
        ThisAgent.speed = MovementSpeed;
        ThisAgent.acceleration = Acceleration;
        ThisAgent.angularSpeed = AngularSpeed;
        ThisAnimator.SetBool(AnimationRunParamName, false);
    }

    public void OnExit() {
        ThisAgent.isStopped = true;
    }
}
