using UnityEngine;
using UnityEngine.XR;

public class VRCamera : MonoBehaviour
{
    public float speed = 1.0f; // The speed of movement
    public float sensitivity = 1.0f; // The sensitivity of the VR controllers
    public bool smoothMovement = true; // Whether or not to use smooth locomotion

    private XRNode leftNode = XRNode.LeftHand; // The left VR controller node
    private XRNode rightNode = XRNode.RightHand; // The right VR controller node
    private Vector3 targetPosition; // The target position of the camera
    private Vector3 velocity; // The current velocity of the camera

    void Update()
    {
        // Get the input values for movement and rotation
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Mouse X");

        // Get the input values from the left VR controller
        Vector2 leftThumbstick = Input.GetAxis("LeftThumbstick");
        Vector2 leftTrackpad = Input.GetAxis("LeftTrackpad");
        float leftTrigger = Input.GetAxis("LeftTrigger");

        // Get the input values from the right VR controller
        Vector2 rightThumbstick = Input.GetAxis("RightThumbstick");
        Vector2 rightTrackpad = Input.GetAxis("RightTrackpad");
        float rightTrigger = Input.GetAxis("RightTrigger");

        // Calculate the target position based on the input values
        Vector3 moveDirection = new Vector3(rightThumbstick.x, 0, rightThumbstick.y);
        targetPosition += transform.TransformDirection(moveDirection) * speed * Time.deltaTime;

        // Smooth the movement if enabled
        if (smoothMovement)
        {
            Vector3 velocityChange = (targetPosition - transform.position) / Time.deltaTime - velocity;
            velocityChange = Vector3.ClampMagnitude(velocityChange, speed);

            velocity += velocityChange * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
        else
        {
            transform.position = targetPosition;
        }

        // Rotate the camera based on the input value
        float rotationAmount = rightThumbstick.x * sensitivity;
        transform.RotateAround(transform.position, Vector3.up, rotationAmount);
    }
}
