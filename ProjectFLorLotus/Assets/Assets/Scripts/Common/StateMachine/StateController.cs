namespace StateMachine
{
        /// <summary>
        /// The StateController handles the switching between different states of an gameObject. It receives the gameObject type as a generic.
        /// </summary>
    public class StateController<ManagedObject>
    {
        public State<ManagedObject> currentState;

        /// <summary>
        /// Changes the current state of the gameObject to the specified state. 
        /// Must only be called inside the when the gameObject is initializing it's first state.
        /// When the gameObject is already in the specified state, use the SwitchState method instead.
        /// </summary>
        public void Initialize(State<ManagedObject> startingState)
        {
            currentState = startingState;
            currentState.Enter();
        }

        /// <summary>
        /// Changes the current state of the gameObject to the specified state. 
        /// It will handle ending the old state and entering the new state.
        /// </summary>
        public void SwitchState(State<ManagedObject> state)
        {
            currentState.Exit();
            currentState = state;
            currentState.Enter();
        }
    }
}