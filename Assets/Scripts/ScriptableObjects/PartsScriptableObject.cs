using System.Collections.Generic;
using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PartsScriptableObject", menuName = "ScriptableObjects/PartsScriptableObject", order = 1)]
    public class PartsScriptableObject: ScriptableObject
    {
        public List<BodyPartData> head;
        public List<BodyPartData> body;
        public List<BodyPartData> leftHand;
        public List<BodyPartData> rightHand;
    }
}