using System.Collections.Generic;
using UnityEngine;

namespace NodePathing
{
    /// <summary>
    /// Adds a simple queue of vectors. Useful for pathfinding routines. Can also be used for other purposes.
    /// </summary>
    public class NodePath : MonoBehaviour
    {
        public List<Vector3> nodesQueue = new();

        /// <summary>
        /// Changes the position of the nodes in the queue to be relative to the position of the gameObject.
        /// </summary>
        public void StartNodes(Vector3 gameObjectPos)
        {
            List<Vector3> vector3s = new();
            nodesQueue.ForEach(node => vector3s.Add(node + gameObjectPos));
            nodesQueue = vector3s;
        }

        /// <summary>
        /// Returns the first node in the queue and cycles the queue.
        /// </summary>
        public Vector3 CycleNodes()
        {
            nodesQueue.Add(nodesQueue[0]);
            var first = nodesQueue[0];
            nodesQueue.RemoveAt(0);

            return first;
        }
    }
}
