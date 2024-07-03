using Core.StateMachine;
using UnityEngine;

namespace Core.Character
{
    public class PlayerController: MonoBehaviour
    {
        [SerializeField] private PlayerStateMachine m_stateMachine;
        [SerializeField] private CharacterMovement m_characterMovement;
    }
}