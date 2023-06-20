using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : IState
{
    public void OnEnter(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void OnExit(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void OnMouseDown(Ball ball, BallStateManager ballStateManager)
    {
        ballStateManager.ChangeState(new DraggingState());
    }

    public void OnMouseDrag(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void OnMouseUp(Ball ball, BallStateManager ballStateManager)
    {
    }

    public void UpdateState(Ball ball, BallStateManager ballStateManager)
    {
    }
}
