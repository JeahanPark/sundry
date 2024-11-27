using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private Animator           m_Animator;
    [SerializeField] private PlayerInput        m_PlayerInput;
    [SerializeField] private float              m_MoveSpeed = 5;
    [SerializeField] private float              m_RotationYSpeed = 5;

    private InputAction m_LookAction;
    private InputAction m_MoveAction;
    private Camera m_Camera;
    private void Awake()
    {
        m_LookAction = m_PlayerInput.actions["Look"];
        m_MoveAction = m_PlayerInput.actions["Move"];

    }

    private void FixedUpdate()
    {
        {
            // 위치
            var dirMove = m_MoveAction.ReadValue<Vector2>();
            var dirPosition = transform.right * dirMove.x + transform.forward * dirMove.y;

            transform.position += dirPosition * m_MoveSpeed * Time.deltaTime;
        }

        {
            // y축 방향
            var dirLook = m_LookAction.ReadValue<Vector2>();
            if(dirLook.x != 0)
            {
                Quaternion additionalRotation = Quaternion.AngleAxis(dirLook.x * m_RotationYSpeed * Time.deltaTime, Vector3.up);
                transform.rotation = transform.rotation * additionalRotation;
            }
        }
        
    }
}
