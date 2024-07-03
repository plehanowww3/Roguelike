using System;
using MVVM.ViewModels;
using ScriptableObjects;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVVM.Views
{
    public class PartShowerView: MonoBehaviour
    {
        [SerializeField] private BodyPart m_bodyPart;
        [SerializeField] private TMP_Text m_bodyNameText;
        [SerializeField] private Image m_image;

        [Inject]
        private PartsScriptableObject m_partsScriptableObject;
        [Inject]
        private PartsViewModel m_partsViewModel;
        
        private void Awake()
        {
            //m_partsViewModel.m_characterParts.ObserveReplace().Subscribe(x => x.);
        }
    }
}