using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState {GoToBase, AttackBase, ChasePlayer, AttackPlayer}

    public EnemyState currentState;

    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;
    public UnityEngine.AI.NavMeshAgent agent;

    void Update(){

        /*
        if(currentState == EnemyState.GoToBase) { GoToBase(); }
        else if (currentState == EnemyState.AttackBase) { AttackBase(); }
        else if (currentState == EnemyState.ChasePlayer) { ChasePlayer(); }
        else{ AttackPlayer(); }
        */
        agent.SetDestination(baseTransform.position);

    }
/*
    void GoToBase() { 

        agent.SetDestination(baseTransform.position);

        if(sightSensor.detectedObject != null){
            currentState = EnemyState.ChasePlayer;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

        if( distanceToBase < baseAttackDistance ){
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase() { 
       currentState = EnemyState.ChasePlayer;
        
    }

    void ChasePlayer() { 

        if(sightSensor.detectedObject == null){
            currentState = EnemyState.GoToBase;
            return;
        }

        float distanceToBase = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if( distanceToBase <= playerAttackDistance ){
            currentState = EnemyState.AttackPlayer;
        }  

        agent.SetDestination(sightSensor.detectedObject.transform.position);
        agent.isStopped = false;
     }

    void AttackPlayer() {

        if(sightSensor.detectedObject == null){
            currentState = EnemyState.GoToBase;
            return;
        }

        float distanceToBase = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if( distanceToBase > playerAttackDistance * 1.1f ){
            currentState = EnemyState.ChasePlayer;
        }
        agent.isStopped = true;

    }
*/
    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);

    }

    private void Awake(){
        baseTransform = GameObject.Find("Player").transform;
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }
   
}
