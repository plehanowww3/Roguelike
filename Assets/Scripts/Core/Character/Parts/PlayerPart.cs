using System;
using Data;
using MVVM.ViewModels;
using UniRx;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Core.Character.Parts
{
    public class PlayerPart: MonoBehaviour, IPlayerPart
    {
        [SerializeField] private CharacterPart m_bodyPart;
        [SerializeField] private SpriteRenderer m_sprite;

        public CharacterPart bodyPart => m_bodyPart;
        public string id => m_bodyPartData.id;
        public string type => m_bodyPartData.avatarType;
        
        [Inject]
        protected PartsViewModel m_partsViewModel;

        private BodyPartData m_bodyPartData;
        private Action m_onAttachAction;
        private Action m_onDetachAction;
        private CompositeDisposable m_disposable;

        private bool inited;
        
        private void Start()
        {
            m_disposable = new CompositeDisposable();

            foreach (var part in m_partsViewModel.m_characterParts)
            {
                if (part.Value.bodyPart == bodyPart)
                    Attach(part.Value);
            }

            m_partsViewModel.m_characterParts
                .ObserveAdd()
                .Subscribe(x =>
                {
                    if (x.Value.bodyPart  == m_bodyPart)
                        Attach(x.Value);
                }).AddTo(m_disposable);
        }

        public void Attach(BodyPartData _partData)
        {
            m_bodyPartData = _partData;
            
            m_sprite.sprite = _partData.sprite;
            m_onAttachAction?.Invoke();
        }

        public void Detach()
        {
            m_onDetachAction?.Invoke();
        }
    }
}