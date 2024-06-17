using System;
using MVVM.ViewModels;
using UnityEngine;
using Zenject;

namespace MVVM.Views
{
    public class PartsControllerView: MonoBehaviour
    {
        [SerializeField] private PartShowerView m_headPartView;
        [SerializeField] private PartShowerView m_bodyPartView;
        [SerializeField] private PartShowerView m_leftHandPartView;
        [SerializeField] private PartShowerView m_rightHandPartView;

        [Inject]
        private PartsViewModel m_partsViewModel;
        
        private void Awake()
        {
            throw new NotImplementedException();
        }
    }
}