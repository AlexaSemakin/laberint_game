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
        float x = Input.GetAxis("Horizontal");// считывание движения по оси Х
        float z = Input.GetAxis("Vertical");// считывание движения по оси Z
        Vector3 move = Vector3.right * x + Vector3.forward * z; // формирование вектора направления transform. вектор, который сохраняет вращение
        controller.Move(move * speed * Time.deltaTime);
    
    
    }
}
