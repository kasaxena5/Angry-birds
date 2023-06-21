using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPoolManager : MonoBehaviour
{
    [SerializeField] List<Ball> balls;

    public void Start()
    {
        GetFirstBallReady();
    }

    public void MoveBalls()
    {
        if (balls.Count > 0)
        {
            Vector2 launchPad = balls[0].GetLaunchPosition();

            Vector2 nextPosition = launchPad;
            Vector2 position = balls[0].GetRestPosition();

            balls[0].MoveToNextRestPosition(nextPosition);
            nextPosition = position;

            for (int i = 1; i < balls.Count; i++)
            {
                position = balls[i].GetRestPosition();
                balls[i].MoveToNextRestPosition(nextPosition);
                nextPosition = position;
            }
        }
    }

    public void GetFirstBallReady()
    {
        if (balls.Count > 0)
            balls[0].MoveToReadyState();
    }

    public void RemoveBall()
    {
        if (balls.Count > 0)
            balls.RemoveAt(0);
        GetFirstBallReady();
    }

}
