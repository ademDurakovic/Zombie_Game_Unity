using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;

    void Update(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayers);
        detectedObject = null;

        for(int i = 0; i < colliders.Length; i++){
            Collider collider = colliders[i];
            Vector3 directionToController = Vector3.Normalize(collider.bounds.center - transform.position);

            float angleToCollider = Vector3.Angle(transform.forward, directionToController);
            if(angleToCollider < angle){
                if(!Physics.Linecast(transform.position, collider.bounds.center, obstaclesLayers)){
                detectedObject = collider;
                break;
                }

            }
        }



    }
}
