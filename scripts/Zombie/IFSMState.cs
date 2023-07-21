using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFSMState
{
    FSMStateType StateName { get; }

    void OnEnter();
    void OnExit();
    void DoAction();
    FSMStateType ShouldTransitionToState();
    
}