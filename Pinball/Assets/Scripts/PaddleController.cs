using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    private float targetPressed;
    private float targetReleased;
    private HingeJoint joint;
    // Start is called before the first frame update
    private void Start()
    {
        joint = GetComponent<HingeJoint>();
        targetPressed = joint.limits.max;
        targetReleased = joint.limits.min;
    }

    // Update is called once per frame
    private void Update()
    {
        ReadInput();
    }
    
    private void ReadInput()
    {
        JointSpring jointSpring = joint.spring;
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetReleased;
        }
        joint.spring = jointSpring;
    }
}
