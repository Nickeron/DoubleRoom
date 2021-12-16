using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rb;

    private Vector3 moveDirection;

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputValue value)
    {
        // Read value from control. The type depends on what type of controls
        // the action is bound to.
        Debug.Log(value);
        var move = value.Get<Vector2>();
        moveDirection = new Vector3(move.x, 0f, move.y).normalized;
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.z * moveSpeed) * Time.deltaTime;
    }
}
