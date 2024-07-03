using System;
using Core.Character;
using Core.StateMachine.States;

namespace Core.StateMachine
{
    [Serializable]
    public class PlayerStateMachine
    {
        public IState CurrentState { get; private set; }
        public PLayerWalkState pLayerWalkState;
        public PLayerIdleState pLayerIdleState;
        
        public PlayerStateMachine(PlayerController player)
        {
            this.pLayerWalkState = new PLayerWalkState(player);
            this.pLayerIdleState = new PLayerIdleState(player);
        }
        
        public void Initialize(IState startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }
        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }
        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}