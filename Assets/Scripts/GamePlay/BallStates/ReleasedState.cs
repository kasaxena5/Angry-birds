using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleasedState : IState
{
    public void OnEnter(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void OnExit(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void OnMouseDown(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void OnMouseDrag(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void OnMouseUp(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void UpdateState(Ball ball, BallStateManager ballStateManager)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ballStateManager.ChangeState(new BoostedState());
        }
    }
}
