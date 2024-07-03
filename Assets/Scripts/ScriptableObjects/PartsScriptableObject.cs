using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PartsScriptableObject", menuName = "ScriptableObjects/PartsScriptableObject", order = 1)]
    public class PartsScriptableObject: ScriptableObject
    {
        [SerializeField] private List<BodyPartData> head;
        [SerializeField] private List<BodyPartData> body;
        [SerializeField] private List<BodyPartData> leftHand;
        [SerializeField] private List<BodyPartData> rightHand;

        public readonly Dictionary<string, BodyPartData> m_partsDictionary = new Dictionary<string, BodyPartData>();

        public readonly Dictionary<CharacterPart, List<BodyPartData>> m_partsByTypeDictionary =
            new Dictionary<CharacterPart, List<BodyPartData>>();

        private void OnEnable()
        {
            AddToDictionary(head);
            AddToDictionary(body);
            AddToDictionary(leftHand);
            AddToDictionary(rightHand);

            m_partsByTypeDictionary[CharacterPart.HEAD] = head;
            m_partsByTypeDictionary[CharacterPart.LEFT_HAND] = leftHand;
            m_partsByTypeDictionary[CharacterPart.RIGHT_HAND] = rightHand;
            m_partsByTypeDictionary[CharacterPart.BODY] = body;
        }
        

        private void AddToDictionary(List<BodyPartData> _list)
        {
            foreach (var part in _list)
            {
                m_partsDictionary[part.id] = part;
                Debug.Log($"Added part{part.id}");
            }
        }
    }
}