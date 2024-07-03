using Data;
using UnityEditor;

namespace Core.Character.Parts
{
    public interface IPlayerPart
    {
        public string id { get; }
        public string type { get; }
        public CharacterPart bodyPart { get; }
        public void Attach(BodyPartData _partData);
        public void Detach();
    }
}