using Data;
using UnityEditor;
using UnityEngine;

namespace Core.Character.Parts
{
    public abstract class PlayerPart: MonoBehaviour, IPlayerPart
    {
        [SerializeField] private BodyPart m_bodyPart;
        [SerializeField] private BodyPartData m_bodyPartData;

        public string id => m_bodyPartData.id;
        public string type => m_bodyPartData.avatarType;
       
        public BodyPart bodyPart => m_bodyPart;

        public abstract void Attach();
        public abstract void Detach();
    }
}