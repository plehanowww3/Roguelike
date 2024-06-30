using System;
using System.Linq;
using Data;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVVM.Views
{
    public class SkillDropDownView: MonoBehaviour
    {
        [SerializeField] private CharacterPart m_characterPart;
        [SerializeField] private TMP_Dropdown m_dropdown;
        
        [Inject]
        private PartsScriptableObject m_partsScriptableObject;

        public string currentId { get; private set; }

        private void Awake()
        {
            // Очистить Dropdown перед добавлением новых элементов
            m_dropdown.ClearOptions();

            // Добавить выбранные варианты в Dropdown
            m_dropdown
                .AddOptions(m_partsScriptableObject.m_partsByTypeDictionary[m_characterPart]
                .Select(x => x.id)
                .ToList());

            currentId = m_dropdown.options[m_dropdown.value].text;
            m_dropdown.onValueChanged.AddListener(x => currentId = m_dropdown.options[x].text);
        }
    }
}