using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Drone
{
    [RequireComponent(typeof(Light2D))]
    public class PlayerFOV : MonoBehaviour
    {
        Transform selfPlayer;

        private void Awake()
        {
            selfPlayer = this.transform.parent;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector3 pPosition = this.transform.position;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, GetMouseVector()+pPosition);
        }

        Vector3 GetMouseVector()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            Vector3 playerPosition = this.transform.position;
            Vector3 mouseDir = mouseWorldPosition - playerPosition;
            

            mouseDir.z = 0;
            Debug.Log(mouseDir);
            return mouseDir;
        }

        void SyncFOVDirection(Vector3 mouseDir)
        {

        }
    }
}