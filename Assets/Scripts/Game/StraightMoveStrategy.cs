using System;
using UnityEngine;

public class StraightMoveStrategy : IMoveStrategy
{
    private Vector2 direction;
    private Transform transform;

    public Transform ControlledTransform
    {
        get
        {
            return transform;
        }
        set
        {
            transform = value;
        }
    }

    public StraightMoveStrategy(Vector2 startingDirection, Transform transform)
    {
        direction = startingDirection;
        direction.Normalize();
        ControlledTransform = transform;
    }

    public void Move(float moveSpeed)
    {
        ControlledTransform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public IMoveStrategy Clone()
    {
        return new StraightMoveStrategy(direction, transform);
    }

}

