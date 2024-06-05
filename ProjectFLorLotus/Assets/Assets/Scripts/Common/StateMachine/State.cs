namespace StateMachine
{
    /// The State class is an abstract class that defines the behavior for different states that an gameObject can be in.
    public abstract class State<ManagedObject>
    {
        protected ManagedObject gameObject;
        protected StateController<ManagedObject> stateController;

        /// <summary>
        /// Initializes a new instance of the State class. It may receive other parameters to handle more specific behavior.
        /// </summary>
        public State(ManagedObject gameObject, StateController<ManagedObject> stateController)
        {
            this.gameObject = gameObject;
            this.stateController = stateController;
        }

        /// <summary>
        /// called when the gameObject enters this state.
        /// </summary>
        public abstract void Enter();
        /// <summary>
        /// called when the gameObject exits this state.
        /// </summary>
        public abstract void Exit();
        /// <summary>
        /// It is called every frame to update the behavior of the gameObject in this state.
        /// </summary>
        public abstract void FrameUpdate();
        /// <summary>
        /// It is called every physics frame to handle physics-related behavior of the gameObject in this state.
        /// </summary>
        public abstract void PhysicsUpdate();
    }
}