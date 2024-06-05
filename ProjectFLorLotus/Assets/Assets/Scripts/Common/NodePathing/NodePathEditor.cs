#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NodePathing
{
    [CustomEditor(typeof(NodePath))]
    public sealed class NodePathPos : Editor
    {
        public void OnSceneGUI()
        {
            var t = target as NodePath;
            var pos = t.transform.position;

            List<Vector3> vector3s = new();
            t.nodesQueue.ForEach(node => vector3s.Add(node + pos));

            var color = new Color(1, 0.8f, 0.4f, 1);
            Handles.color = color;

            for (int i = 0; i < vector3s.Count; i++)
            {
                if (i + 1 >= vector3s.Count)
                {
                    Handles.DrawLine(vector3s[i], vector3s[0]);
                    break;
                }
                Handles.DrawLine(vector3s[i], vector3s[i + 1]);
            }
            GUI.color = color;
        }
    }
}
#endif
