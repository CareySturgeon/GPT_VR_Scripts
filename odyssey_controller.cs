using UnityEngine;
using UnityEngine.XR;

public class OdysseyController : MonoBehaviour
{
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
            // Do something with the trigger input value
        }

        if (leftController.TryGetFeatureValue(CommonUsages.grip, out float leftGripValue))
        {
            // Do something with the grip input value
        }

        // Check for input from the right controller
        if (rightController.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerValue))
        {
            // Do something with the trigger input value
        }

        if (rightController.TryGetFeatureValue(CommonUsages.grip, out float rightGripValue))
        {
            // Do something with the grip input value
        }
    }
}