using UnityEngine;
using UnityEngine.XR;

public class OdysseyController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // The movement speed of the player character

    private InputDevice leftController;
    private InputDevice rightController;
    
    void Start()
    {
        // Get the left and right Samsung Odyssey controllers
        var leftHandedDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandedDevices);
        if (leftHandedDevices.Count > 0)
        {
            leftController = leftHandedDevices[0];
        }

        var rightHandedDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandedDevices);
        if (rightHandedDevices.Count > 0)
        {
            rightController = rightHandedDevices[0];
        }
    }

    void Update()
    {
        // Check for input from the left controller
        if (leftController.TryGetFeatureValue(CommonUsages.trigger, out float leftTriggerValue))
        {
            // Move the player character forward based on the trigger input value
            Vector3 forwardMovement = transform.forward * leftTriggerValue * moveSpeed * Time.deltaTime;
            transform.position += forwardMovement;
        }

        // Check for input from the right controller
        if (rightController.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerValue))
        {
            // Rotate the player character based on the trigger input value
            float rotationAmount = rightTriggerValue * 90.0f * Time.deltaTime;
            transform.Rotate(0.0f, rotationAmount, 0.0f);
        }
    }
}
