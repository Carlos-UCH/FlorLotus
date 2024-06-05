using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace TurretEnemy
{
    public class PatrolState : State<TurretEnemy>
    {
        public float rotationSpeed = 2f; // Adjust for desired rotation speed (degrees per second)
        public Vector3[] directions = new Vector3[] { Vector3.right, Vector3.down, Vector3.left, Vector3.up };
        private int currentDirectionIndex = 0;


        public PatrolState(TurretEnemy gameObject, StateController<TurretEnemy> stateController) : base(gameObject, stateController)
        {
            this.gameObject = gameObject;
            this.stateController = stateController;
        }

        public override void Enter()
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        public override void Exit()
        {
        }

        public override void FrameUpdate()
        {
            this.gameObject.facingDirection = Vector3.RotateTowards(this.gameObject.facingDirection, directions[currentDirectionIndex], rotationSpeed * Time.deltaTime, 1f);

            if (Mathf.Abs(Vector3.Angle(this.gameObject.facingDirection, directions[currentDirectionIndex])) < 0.1f) // Adjust tolerance as needed
            {
                currentDirectionIndex = (currentDirectionIndex + 1) % directions.Length;
            }
        }

        public override void PhysicsUpdate()
        {
        }
    }
}