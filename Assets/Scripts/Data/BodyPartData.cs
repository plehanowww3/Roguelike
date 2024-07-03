using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class BodyPartData
    {
        public string id;
        public CharacterPart bodyPart;
        public string avatarType;
        public Sprite sprite;
    }
}