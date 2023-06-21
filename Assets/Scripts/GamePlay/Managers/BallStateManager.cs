using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallStateManager : MonoBehaviour
{
    IState currentState;
    Ball ball;

    NotReadyState notReadyState = new();
    void Awake()
    {
        ball = GetComponent<Ball>();    
    }

    void Start()
    {
        ChangeState(notReadyState);
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateState(ball, this);
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.OnExit(ball, this);
        currentState = newState;
        currentState.OnEnter(ball, this);
    }

    private void OnMouseDown()
    {
        if (currentState != null)
            currentState.OnMouseDown(ball, this);
    }

    private void OnMouseDrag()
    {
        if (currentState != null)
            currentState.OnMouseDrag(ball, this);
    }

    private void OnMouseUp()
    {
        if (currentState != null)
            currentState.OnMouseUp(ball, this);
    }

}

public interface IState
{
    public void OnEnter(Ball ball, BallStateManager ballStateManager);
    public void UpdateState(Ball ball, BallStateManager ballStateManager);
    public void OnMouseDrag(Ball ball, BallStateManager ballStateManager);
    public void OnMouseUp(Ball ball, BallStateManager ballStateManager);
    public void OnMouseDown(Ball ball, BallStateManager ballStateManager);
    public void OnExit(Ball ball, BallStateManager ballStateManager);
}
