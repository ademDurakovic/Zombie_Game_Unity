using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightLine : MonoBehaviour
{
    public Transform EyePoint;
    public float FieldOfView = 45f;
    public bool IsTargetInSightLine;
    public string TargetTag;
    public Vector3 LastKnowSighting;



    private bool HasClearLineofSightToTarget(Transform Target){
        RaycastHit Info;
        Vector3 DirToTarget = (Target.position - EyePoint.position).normalized;

//        string TargetTag = Target.gameObject.tag;
        SphereCollider ThisCollider = this.gameObject.GetComponent<SphereCollider>();

        if(Physics.Raycast(EyePoint.position, DirToTarget, out Info, ThisCollider.radius)){
            if (Info.transform.CompareTag(TargetTag)){
                return true;
            }
        }
        return false;

    }

    private bool TargetInFOV(Transform Target){
        Vector3 DirToTarget = Target.position - EyePoint.position;
        float Angle = Vector3.Angle(EyePoint.forward, DirToTarget);

        if (Angle <= FieldOfView){
            return true;
        }
        return false;
    }

    void OnTriggerStay(Collider Other){

        if(Other.CompareTag(TargetTag)){
            UpdateSight(Other.transform);
        }
    }

    void OnTriggerExit(Collider Other){

        if(Other.CompareTag(TargetTag)){
            IsTargetInSightLine = false;
        }
    }

    private void UpdateSight(Transform Target){
        bool IsT = HasClearLineofSightToTarget(Target) && TargetInFOV(Target);
        if(IsTargetInSightLine){
            LastKnowSighting = Target.position;
        }
    }

}
