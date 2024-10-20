using System;
using UnityEngine;

public abstract class BaseActorInputController : MonoBehaviour
{
    protected float xAxisValue;
    protected float yAxisValue;

    public abstract void RegisterMoveHandler(Action<Vector2> handler);

    public abstract void RegisterPhysicsMoveHandler(Action<Vector2> handler);
}
