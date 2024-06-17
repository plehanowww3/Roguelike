using System;
using UnityEngine;

namespace Core.Character.Parts
{
    public class PlayerPartController: MonoBehaviour
    {
        [SerializeField] private PlayerPart m_headPart;
        [SerializeField] private PlayerPart m_bodyPart;
        [SerializeField] private PlayerPart m_leftHandPart;
        [SerializeField] private PlayerPart m_rightHandPart;

        private void Awake()
        {
            throw new NotImplementedException();
        }
    }
}