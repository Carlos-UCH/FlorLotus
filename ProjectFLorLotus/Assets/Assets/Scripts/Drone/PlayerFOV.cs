using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Drone
{
    [RequireComponent(typeof(Light2D))]
    public class PlayerFOV : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = 10;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            Vector3 playerPosition = this.transform.position;
            Vector3 mouseDir = mouseWorldPosition - playerPosition;

            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, mouseDir.normalized);
        }
    }
}