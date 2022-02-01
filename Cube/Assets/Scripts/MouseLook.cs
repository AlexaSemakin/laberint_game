using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSpeed = 90f;
    public Transform playerBody;
    float rotationY = 0f;

    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }


    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime; // движение по горизонтали
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime; // движение по вертикали
        playerBody.Rotate(Vector3.up * mouseX);
        //playerBody.Rotate(Vector3.left * mouseY);
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -45f, 45f);

        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);//поворачиваем камеру по вертикали

    }
}
