using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : ScriptableObject
{
    private float verticalRotationSupportValue;
    private float verticalRotation = 180f;
    private float horizontalRotation = 0f;
    public void PlayerRotation(GameObject objectVerticalRotation,GameObject objectHorizontalRotation, Camera camera, float mouseSpeed)
    {
        horizontalRotation += Input.GetAxis("Mouse X") * mouseSpeed;
        verticalRotationSupportValue -= Input.GetAxis("Mouse Y") * mouseSpeed;
        verticalRotation = Mathf.Clamp(verticalRotationSupportValue, -70, 70);
        objectVerticalRotation.transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, objectVerticalRotation.transform.rotation.z);
        objectHorizontalRotation.transform.rotation = Quaternion.Euler(objectHorizontalRotation.transform.rotation.x, horizontalRotation, objectHorizontalRotation.transform.rotation.z);

    }
   public void WeaponRotation(GameObject weaponLeft,GameObject weaponRight, Camera camera)
   {
       weaponLeft.transform.LookAt(camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth / 2.0f+5f, camera.pixelHeight / 2.0f + 20, camera.farClipPlane)));
       weaponRight.transform.LookAt(camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth / 2.0f-5f, camera.pixelHeight / 2.0f + 20, camera.farClipPlane)));
   }
}
