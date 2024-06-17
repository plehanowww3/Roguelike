using System;
using Core.Character;
using Core.StateMachine.States;

namespace Core.StateMachine
{
    [Serializable]
    public class PlayerStateMachine
    {
        public IState CurrentState { get; private set; }
        public WalkState walkState;
        public IdleState idleState;
        
        public PlayerStateMachine(PlayerController player)
        {
            this.walkState = new WalkState(player);
            this.idleState = new IdleState(player);
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