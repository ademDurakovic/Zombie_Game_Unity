using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AttackState : MonoBehaviour, IFSMState
{
    public FSMStateType StateName { get { return FSMStateType.Attack; } }
    public string AnimationRunParamName = "Attack";
    public float EscapeDistance = 10.0f;
    public float MaxAttackDistance = 2.0f;
    public string TargetTag = "Player";
    public float DelayBetweenAttacks = 2.0f;

    private Animator ThisAnimator;
    private NavMeshAgent ThisAgent;
    private bool IsAttacking = false;
    private Transform Target;

    private void Awake() {
        ThisAgent = GetComponent<NavMeshAgent>();
        ThisAnimator = GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag(TargetTag).transform;
    }

    public void OnEnter() {
        StartCoroutine(DoAttack());
    }

    public void OnExit() {
        ThisAgent.isStopped = true;
        IsAttacking = false;
        StartCoroutine(DoAttack());
    }

    public void DoAction() {
        IsAttacking = Vector3.Distance(Target.position, transform.position) < MaxAttackDistance;

        if(!IsAttacking) {
            ThisAgent.isStopped = false;
            ThisAgent.SetDestination(Target.position);
        }
    }

    public FSMStateType ShouldTransitionToState() {
        if (Vector3.Distance(Target.position, transform.position) > EscapeDistance) {
            return FSMStateType.Chase;
        }

        return FSMStateType.Attack;
    }

    private IEnumerator DoAttack() {
        while(true) {
            if (IsAttacking) {
                Debug.Log("Attack player");
                ThisAnimator.SetTrigger(AnimationRunParamName);
                ThisAgent.isStopped = true;

                yield return new WaitForSeconds(DelayBetweenAttacks);
            }
            yield return null;
        }
    }




}



