using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using ScriptableObjects;
using UniRx;
using UnityEngine;
using Zenject;

namespace MVVM.ViewModels
{
    public class PartsViewModel: ViewModel
    {
        public ReactiveDictionary<string, BodyPartData> m_characterParts;
        
        public ReactiveProperty<string> avatarType;
        public ReactiveProperty<bool> isAllSameType;
        
        public ReactiveCommand<string> setBodyPart;
        public ReactiveCommand onAllPartsLoaded;

        [Inject]
        private PartsScriptableObject m_partsScriptableObject;

        public PartsViewModel(Model _model): base(_model)
        {
            Debug.Log("Constrictor ExampleViewModel");

            avatarType = model.avatarType;
            m_characterParts = model.m_characterParts;
            isAllSameType = model.isAllSameType;
            setBodyPart = new ReactiveCommand<string>();
            onAllPartsLoaded = new ReactiveCommand();

            setBodyPart.Subscribe(SetNewPart);
        }
        
        private bool CheckIfAllSameType()
        {
            // Получаем первый avatarType из словаря
            string firstAvatarType = m_characterParts.Values.First().avatarType;

            // Проверяем, что все элементы имеют тот же avatarType
            var sameAvatarType =  m_characterParts.Values.All(part => part.avatarType == firstAvatarType);
            model.avatarType.Value = sameAvatarType ? firstAvatarType : string.Empty;

            isAllSameType.Value = sameAvatarType;
            return sameAvatarType;
        }
        
        public void SetNewPart(string _partId)
        {
            //todo выяснить почему сюда приходит
            if (String.IsNullOrEmpty(_partId))
                return;
            
            var newPart = m_partsScriptableObject.m_partsDictionary
                .FirstOrDefault(x => x.Key.Equals(_partId));
            
            if (newPart.Equals(default(KeyValuePair<string, BodyPartData>)))
                return;
            
            var oldItemSameType = m_characterParts.FirstOrDefault(x => x.Value.bodyPart == newPart.Value.bodyPart);
            if (!Equals(String.IsNullOrEmpty(oldItemSameType.Key)) && oldItemSameType.Value != null)
            {
                if (newPart.Key.Equals(oldItemSameType.Key))
                    return;
                
                if (m_characterParts.ContainsKey(oldItemSameType.Key))
                    m_characterParts.Remove(oldItemSameType.Key);
            }
            
            Debug.Log($"Set {_partId} part");
            model.m_characterParts[_partId] = newPart.Value;
            CheckIfAllSameType();
        }
    }
}