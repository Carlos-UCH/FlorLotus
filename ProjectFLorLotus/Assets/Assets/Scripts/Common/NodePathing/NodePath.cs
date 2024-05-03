using System.Collections.Generic;
using UnityEngine;

namespace NodePathing
{
    public class NodePath : MonoBehaviour
    {
        public List<Vector3> nodesQueue = new();

        public void StartNodes(Vector3 originalPosition)
        {
            List<Vector3> vector3s = new();
            nodesQueue.ForEach(node => vector3s.Add(node + originalPosition));
            nodesQueue = vector3s;
        }

        public Vector3 CycleNodes()
        {
            nodesQueue.Add(nodesQueue[0]);
            var first = nodesQueue[0];
            nodesQueue.RemoveAt(0);

            return first;
        }
    }
}
