using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    private Vector3 storedDestination;
    private PlayerInput _input;

    public PlayerState PlayerState;

    private Vector2 _leftJoystickInput;
    public float inputThreshold = 0.1f;
    private bool pathInterrupted = false;

    public PathTest pathTest;

    private bool interruptedByMouse;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.PlayerControls.Move.performed += ctx => _leftJoystickInput = ctx.ReadValue<Vector2>();
        _input.PlayerControls.MouseMove.performed += ctx => MouseMove();
    }
    
    void Update()
    {
        if (_leftJoystickInput.magnitude > inputThreshold)
        {
            Move(_leftJoystickInput);
        }
        else if (interruptedByMouse)
        {
            if (agent.remainingDistance < 0.5f)
            {
                interruptedByMouse = false;
            }
        }
        else if (pathInterrupted)
        {
            pathTest.GotoNextPoint(storedDestination);
            pathInterrupted = false;
        }
    }

    private void Move(Vector2 input)
    {
        if (PlayerState.autoRoaming) InterruptAutoRoaming(false);
        
        Vector3 direction = Vector3.right * input.x + Vector3.forward * input.y;
        agent.Move(Time.deltaTime * agent.speed * direction);
    }

    void MouseMove()
    {
        if (PlayerState.autoRoaming) InterruptAutoRoaming(true);
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    private void InterruptAutoRoaming(bool interruptedByMouse)
    {
        this.interruptedByMouse = interruptedByMouse;
        PlayerState.autoRoaming = false;
        pathInterrupted = true;
        storedDestination = agent.destination;
        agent.ResetPath();
    }
    
    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
