using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;

    void Update()
    {
        RunStateMachine();

    }
    private void RunStateMachine()
    {//Debug.Log("running!!!");
        State nextState = currentState?.RunCurrentState();
        //gets the next state

        if (nextState != null)
        { //switch to next state from current to "next"
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
