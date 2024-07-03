using System;
using MVVM.ViewModels;
using UnityEngine;
using Zenject;

namespace Core
{
    public class TestPartItem: MonoBehaviour
    {
        [SerializeField] private string m_partId;

        [Inject]
        private PartsViewModel m_partsViewModel;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                m_partsViewModel.setBodyPart.Execute(m_partId);
            }
        }
    }
}