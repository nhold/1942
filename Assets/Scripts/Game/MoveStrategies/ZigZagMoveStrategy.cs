using System;
using UnityEngine;

public class ZigZagMoveStrategy : IMoveStrategy
{
    private Vector2 direction;
    private Transform transform;
    private Vector3 newPosition;

    float zigAmplitude = 5.0f;
    float zagFrequency = 1.0f;

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

    public ZigZagMoveStrategy(Vector2 startingDirection, Transform transform, float zigAmplitude, float zagFrequency)
    {
        direction = startingDirection;
        direction.Normalize();
        ControlledTransform = transform;

        this.zigAmplitude = zigAmplitude;
        this.zagFrequency = zagFrequency;
    }

    public void Move(float moveSpeed)
    {
        ControlledTransform.Translate((direction * moveSpeed * Time.deltaTime));

        newPosition = transform.position;
        newPosition.x += zigAmplitude * Mathf.Sin(zagFrequency * Time.time);
        transform.position = newPosition;
    }

    public IMoveStrategy Clone()
    {
        return new ZigZagMoveStrategy(direction, transform, zigAmplitude, zagFrequency);
    }

}

