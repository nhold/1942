using UnityEngine;

public class SmoothMouseInputMoveStrategy : IMoveStrategy 
{
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

    public SmoothMouseInputMoveStrategy(Transform transform)
    {
        ControlledTransform = transform;
    }

    public void Move(float moveSpeed)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        ControlledTransform.position = Vector3.MoveTowards(ControlledTransform.position, mouseWorldPosition, moveSpeed * Time.deltaTime);
    }

    public IMoveStrategy Clone()
    {
        return new MouseInputMoveStrategy(transform);
    }
}
