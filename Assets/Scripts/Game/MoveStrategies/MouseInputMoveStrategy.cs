using UnityEngine;

public class MouseInputMoveStrategy : IMoveStrategy 
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

    public MouseInputMoveStrategy(Transform transform)
    {
        ControlledTransform = transform;
    }

    public void Move(float moveSpeed)
    {
        Vector3 mouse = Input.mousePosition;
        Vector2 direction = Camera.main.ScreenToWorldPoint(mouse) - ControlledTransform.position;
        direction.Normalize();

        ControlledTransform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public IMoveStrategy Clone()
    {
        return new MouseInputMoveStrategy(transform);
    }
}
