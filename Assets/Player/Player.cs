using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    public Action OnPowerStart;
    public Action OnPowerStop;

    [Header("Config")]
    [SerializeField] private float _speed;
    [SerializeField] Camera _camera;
    [SerializeField]private float _powerupDuration;
    [SerializeField] private int _health;
    [SerializeField] private Transform _respwanPoint;
    [SerializeField] private TMP_Text _healthText;


    private Rigidbody _rigidbody;
    // [SerializeField] Coroutine _powerupCoroutine;
    private Coroutine _powerupCoroutine;
    private bool _isPowerUpActive = false;
    //private bool _isPowerUpActive;


    public void Dead() 
    {
        _health -= 1;
        
         if(_health > 0)
         {
             transform.position = _respwanPoint.position;
         }
         else
         {
             _health = 0;
             Debug.Log("Lose");
         }
        UpdateUI();
    }
    public void PickPowerUp() 
    {
       
        //Debug.Log("Pick Power Up");
        if (_powerupDuration != 0)
        {
            if(_powerupCoroutine != null)
            {
                StopCoroutine(_powerupCoroutine);
            }
            _powerupCoroutine = StartCoroutine(StartPowerUp());
        }
    }

    private IEnumerator StartPowerUp() { 
    _isPowerUpActive = true;
       if(OnPowerStart != null)
        {
            OnPowerStart();
        }
        // Debug.Log("Start Power Up");
        yield return new WaitForSeconds(_powerupDuration);
        
        // Debug.Log("Stop Power up");
    _isPowerUpActive=false;
        if (OnPowerStop != null)
        {
            OnPowerStop();
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        HideAndLockCursor();
        UpdateUI();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (_isPowerUpActive)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().Dead();
            }
        }
        
    }

    private void UpdateUI()
    {
        _healthText.text = "Health :"+ _health;
    }

}
