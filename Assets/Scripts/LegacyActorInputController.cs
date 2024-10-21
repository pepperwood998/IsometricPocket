using System;
using UnityEngine;

public class LegacyActorInputController : BaseActorInputController
{
    private Action<Vector2> _onInputMove;
    private Action<Vector2> _onInputPhysicsMove;
    private Action _onInteract;
    private Action _onDrop;

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

    public override void RegisterInteractionHandler(Action handler)
    {
        _onInteract = handler;
    }

    public override void RegisterDropHandler(Action handler)
    {
        _onDrop = handler;
    }

    private void ProcessInput()
    {
        xAxisValue = Input.GetAxis(HorizontalAxisName);
        yAxisValue = Input.GetAxis(VerticalAxisName);

        if (Input.GetKeyDown(KeyCode.E))
        {
            _onInteract?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _onDrop?.Invoke();
        }
    }

    private readonly string HorizontalAxisName = "Horizontal";
    private readonly string VerticalAxisName = "Vertical";
}
