using Core.Character;

namespace Core.StateMachine.States
{
    public class PLayerIdleState : IState
    {
        private PlayerController player;
        public PLayerIdleState(PlayerController player)
        {
            this.player = player;
        }
        public void Enter()
        {

        }
        public void Update()
        {

        }
        public void Exit()
        {

        }
    }
}