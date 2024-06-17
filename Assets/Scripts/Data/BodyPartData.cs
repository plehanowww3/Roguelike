using System;
using UnityEditor;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class BodyPartData
    {
        public BodyPart bodyPart;
        public string id;
        public string typeId;
        public Sprite sprite;
    }
}