using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float _speed;
    [SerializeField] Camera _camera;


    Rigidbody _rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        HideAndLockCursor();
    }

    private void HideAndLockCursor() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");

        Vector3 horizontalDirection = horizontal*_camera.transform.right;
        Vector3 verticalDirection = vertical*_camera.transform.forward;
        horizontalDirection.y = 0;
        verticalDirection.y = 0;

        Vector3 movementDirection = horizontalDirection + verticalDirection;
        //Vector3 movementDirection = new Vector3(horizontal,0,vertical);
        _rigidbody.velocity = movementDirection*_speed*Time.fixedDeltaTime;
    }

}
