using Data;
using UnityEditor;

namespace Core.Character.Parts
{
    public interface IPlayerPart
    {
        public string id { get; }
        public string type { get; }
        public BodyPart bodyPart { get; }
        public void Attach();
        public void Detach();
    }
}