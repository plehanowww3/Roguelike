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

        [Inject]
        private PartsScriptableObject m_partsScriptableObject;

        public PartsViewModel(Model _model): base(_model)
        {
            Debug.Log("Constrictor ExampleViewModel");

            avatarType = model.avatarType;
            m_characterParts = model.m_characterParts;
            isAllSameType = model.isAllSameType;
            setBodyPart = new ReactiveCommand<string>();

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
            var newPart = m_partsScriptableObject.m_partsDictionary
                .FirstOrDefault(x => x.Key.Equals(_partId));
                
            Debug.Log($"Set {_partId} part");
            model.m_characterParts[_partId] = newPart.Value;
            CheckIfAllSameType();
        }
    }
}