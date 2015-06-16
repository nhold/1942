using System;
using UnityEngine;

public interface IMoveStrategy
{
    Transform ControlledTransform
    {
        get;
        set;
    }

    void Move(float moveSpeed);

    IMoveStrategy Clone();
}

