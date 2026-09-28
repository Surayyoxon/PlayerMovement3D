using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float gravity = 18f;

    private float groundY;
    private float verticalSpeed;

    private void Start()
    {
        groundY = transform.position.y;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= groundY)
        {
            Jump();
        }

        verticalSpeed -= gravity * Time.deltaTime;

        Vector3 movement = direction * moveSpeed;
        movement.y = verticalSpeed;
        transform.position += movement * Time.deltaTime;

        if (transform.position.y < groundY)
        {
            Vector3 position = transform.position;
            position.y = groundY;
            transform.position = position;
            verticalSpeed = 0f;
        }
    }

    private void Jump()
    {
        verticalSpeed = jumpForce;
    }
}
