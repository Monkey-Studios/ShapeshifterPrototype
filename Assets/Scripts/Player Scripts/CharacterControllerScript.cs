using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class CharacterControllerScript : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public float rotationSpeed = 5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public int currentPlayer = 0;
    public int[] players;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if(Input.GetButton("Jump")&& currentPlayer == 0 || currentPlayer == 2 && Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }

}
