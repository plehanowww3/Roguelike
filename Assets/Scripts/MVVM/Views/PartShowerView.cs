using System;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace MVVM.Views
{
    public class PartShowerView: MonoBehaviour
    {
        [SerializeField] private BodyPart m_bodyPart;
        [SerializeField] private TMP_Text m_bodyNameText;

        private void Awake()
        {
            
        }
    }
}