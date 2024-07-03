using System;
using MVVM.ViewModels;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVVM.Views.Cheats
{
    public class PartCheatMenu: MonoBehaviour
    {
        [SerializeField] private Button m_chooseFirstHead;
        [SerializeField] private SkillDropDownView m_headDropDownView;
        [SerializeField] private SkillDropDownView m_leftHandDropDownView;
        [SerializeField] private SkillDropDownView m_rightHandDropDownView;
        [SerializeField] private SkillDropDownView m_bodyDropDownView;

        [Inject]
        private PartsViewModel m_skillsViewModel;

        private void Awake()
        {
            m_chooseFirstHead.onClick.AddListener(OnNewItemSelected);
        }

        private void Start()
        {
            OnNewItemSelected();
        }

        private void OnNewItemSelected()
        {
            m_skillsViewModel.setBodyPart.Execute(m_headDropDownView.currentId);
            m_skillsViewModel.setBodyPart.Execute(m_leftHandDropDownView.currentId);
            m_skillsViewModel.setBodyPart.Execute(m_rightHandDropDownView.currentId);
            m_skillsViewModel.setBodyPart.Execute(m_bodyDropDownView.currentId);
        }
    }
}