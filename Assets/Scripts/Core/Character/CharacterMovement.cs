using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Character
{
    public class CharacterMovement: MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D m_rb; 
        [SerializeField] private float m_moveSpeed;
        private Vector2 m_moveInput;

        private InputAction move;
        private PlayerInputActions m_playerMoveAction;

        private void Awake()
        {
            m_playerMoveAction = new PlayerInputActions();
        }

        private void OnEnable()
        {
            move = m_playerMoveAction.Player.Move;
            m_playerMoveAction.Enable();
        }

        private void OnDisable()
        {
            m_playerMoveAction.Disable();
        }

        void Update()
        {
            m_moveInput = move.ReadValue<Vector2>();
        }
    
        void FixedUpdate()
        {
            m_rb.velocity = new Vector2(m_moveInput.x * m_moveSpeed, m_moveInput.y * m_moveSpeed);
        }
    }
}

