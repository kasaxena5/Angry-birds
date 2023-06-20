using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingState : IState
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
        ball.Drag();
    }

    public void OnMouseUp(Ball ball, BallStateManager ballStateManager)
    {
        ball.MouseUp();
        ballStateManager.ChangeState(new ReleasedState());
    }

    public void UpdateState(Ball ball, BallStateManager ballStateManager)
    {
    }
}
