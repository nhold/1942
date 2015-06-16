using System;
using UnityEngine;

class Moveable : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private IMoveStrategy moveStrategy;

    public IMoveStrategy MoveStrategy
    {
        get
        {
            return moveStrategy;
        }

        set
        {
            moveStrategy = value;
        }
    }
    
    private void Update()
    {
        if(moveStrategy != null)
            moveStrategy.Move(moveSpeed);
    }
}

