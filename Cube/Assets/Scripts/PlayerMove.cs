using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    CharacterController controller;
    public float speed = 10f;

    void Start()
    {
        gameObject.transform.position =new Vector3(0, 0, 0);
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");// ���������� �������� �� ��� �
        float z = Input.GetAxis("Vertical");// ���������� �������� �� ��� Z
        Vector3 move = Vector3.right * x + Vector3.forward * z; // ������������ ������� ����������� transform. ������, ������� ��������� ��������
        controller.Move(move * speed * Time.deltaTime);
    
    
    }
}
