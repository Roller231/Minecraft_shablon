using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость движения персонажа
    public float LastClickTime = 0.0f;
    [SerializeField] private bool flipUseGravity;

    private CharacterController controller;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
 
            float timeFromLastClick = Time.time - LastClickTime;
            LastClickTime = Time.time;
            if (timeFromLastClick < 0.7 && !flipUseGravity){GetComponent<Rigidbody>().useGravity = false; flipUseGravity = true;}
            else if (timeFromLastClick < 0.7 && flipUseGravity){GetComponent<Rigidbody>().useGravity = true; flipUseGravity = false;}


        }
        // Получаем ввод от игрока
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Вычисляем направление движения
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        
        // Применяем гравитацию
        moveDirection.y -= 9.81f * Time.deltaTime;
        
        // Двигаем персонажа
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}