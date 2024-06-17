using System;

namespace Core.Character.Parts
{
    public class PlayerHeadPart: PlayerPart
    {
        private Action m_onAttachAction;
        private Action m_onDetachAction;
            
        public override void Attach()
        {
            m_onAttachAction?.Invoke();
        }

        public override void Detach()
        {
            m_onDetachAction?.Invoke();
        }
    }
}