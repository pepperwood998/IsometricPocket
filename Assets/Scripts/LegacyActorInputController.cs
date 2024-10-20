using System;
using UnityEngine;

public class LegacyActorInputController : BaseActorInputController
{
    private Action<Vector2> _onInputMove;
    private Action<Vector2> _onInputPhysicsMove;

    private void Update()
    {
        ProcessInput();

        _onInputMove?.Invoke(new Vector2(xAxisValue, yAxisValue));
    }
    private void FixedUpdate()
    {
        _onInputPhysicsMove?.Invoke(new Vector2(xAxisValue, yAxisValue));
    }

    public override void RegisterMoveHandler(Action<Vector2> handler)
    {
        _onInputMove = handler;
    }

    public override void RegisterPhysicsMoveHandler(Action<Vector2> handler)
    {
        _onInputPhysicsMove = handler;
    }

    private void ProcessInput()
    {
        xAxisValue = Input.GetAxis(HorizontalAxisName);
        yAxisValue = Input.GetAxis(VerticalAxisName);
    }

    private readonly string HorizontalAxisName = "Horizontal";
    private readonly string VerticalAxisName = "Vertical";
}
