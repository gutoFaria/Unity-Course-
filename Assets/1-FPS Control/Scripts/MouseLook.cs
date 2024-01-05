using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityFPS
{
    public class MouseLook : MonoBehaviour
    {
        public enum RotationAxes
        {
            MouseXAndY = 0,
            MouseX = 1,
            MouseY = 2
        }

        public RotationAxes axes = RotationAxes.MouseXAndY;
        public float sensitivityHor = 9.0f;
        public float sensitivityVer = 9.0f;
        public float minimumVert = -45.0f;
        public float maximumVert = 45.0f;
        private float verticalRot = 0;

        void Start()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if(body != null)
            {
                body.freezeRotation = true;
            }
        }
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            if(axes == RotationAxes.MouseX)
            {
                // horizantal rotation
                
                transform.Rotate(0,mouseX * sensitivityHor,0);
            }
            else if(axes == RotationAxes.MouseY)
            {
                // vertical rotation
                
                verticalRot -= mouseY * sensitivityVer;
                verticalRot = Mathf.Clamp(verticalRot,minimumVert,maximumVert);

                float horizontalRot = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(verticalRot,horizontalRot,0); 
            }
            else
            {
                // Horizontal and vertical rotation
                verticalRot -= mouseY * sensitivityVer;
                verticalRot = Mathf.Clamp(verticalRot,minimumVert,maximumVert);

                float delta = mouseX * sensitivityHor;
                float horizontalRot = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(verticalRot,horizontalRot,0);
            }
        }
    }
}

