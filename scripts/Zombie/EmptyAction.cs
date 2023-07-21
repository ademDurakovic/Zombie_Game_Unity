using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyAction : IFSMState
{
    public FSMStateType StateName { get { return FSMStateType.None; } }

    public void DoAction() {}
    public void OnEnter() {}
    public void OnExit() {}

    public FSMStateType ShouldTransitionToState() {
        return FSMStateType.None;
    }
}
