using System.Collections.Generic;
using UnityEngine;

namespace Data.Abilities.Interfaces
{
    public interface IAbility
    {
        public string Name { get; }
        public List<string> Tags { get; }
        public string Description { get; }
        public Sprite Icon { get; }
        public void Activate();
    }
}