using System;
using MVVM.ViewModels;
using UnityEngine;
using Zenject;

namespace Core.Character.Parts
{
    public class PlayerPartController: MonoBehaviour
    {
        [SerializeField] private PlayerPart m_headPart;
        [SerializeField] private PlayerPart m_bodyPart;
        [SerializeField] private PlayerPart m_leftHandPart;
        [SerializeField] private PlayerPart m_rightHandPart;

        [Inject]
        private PartsViewModel m_partsViewModel;

        private void Awake()
        {
            throw new NotImplementedException();
        }
    }
}