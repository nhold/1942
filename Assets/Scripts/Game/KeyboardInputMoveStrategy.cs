using UnityEngine;
using System.Collections;

public class KeyboardInputMoveStrategy : IMoveStrategy {

	private Vector2 direction;
    private Transform transform;

    private KeyCode moveLeftKeyCode = KeyCode.LeftArrow;
    private KeyCode moveRightKeyCode = KeyCode.RightArrow;
    private KeyCode moveForwardKeyCode = KeyCode.UpArrow;
    private KeyCode moveBackwardKeyCode = KeyCode.DownArrow;

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

    public KeyboardInputMoveStrategy(Vector2 startingDirection, Transform transform)
    {
        direction = startingDirection;
        direction.Normalize();
        ControlledTransform = transform;
    }

    public void Move(float moveSpeed)
    {
        if (Input.GetKey(moveLeftKeyCode))
        {
            MoveLeft(moveSpeed);
        }

        if (Input.GetKey(moveRightKeyCode))
        {
            MoveRight(moveSpeed);
        }

        if (Input.GetKey(moveForwardKeyCode))
        {
            MoveForward(moveSpeed);
        }

        if (Input.GetKey(moveBackwardKeyCode))
        {
            MoveBackward(moveSpeed);
        }
    }

    void MoveLeft(float speed)
    {
        var movementAmount = -speed * Time.deltaTime;

        if (transform.position.x + movementAmount > -290)
            transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
    }

    void MoveRight(float speed)
    {
        var movementAmount = speed * Time.deltaTime;

        if (transform.position.x + movementAmount < 290)
            transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
    }

    void MoveForward(float speed)
    {
        var movementAmount = speed * Time.deltaTime;

        if (transform.position.y + movementAmount < 218)
            transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
    }

    void MoveBackward(float speed)
    {
        var movementAmount = -speed * Time.deltaTime;

        if (transform.position.y + movementAmount > -220)
            transform.Translate(0.0f, movementAmount, 0.0f);
    }

    public IMoveStrategy Clone()
    {
        return new KeyboardInputMoveStrategy(direction, transform);
    }
}
