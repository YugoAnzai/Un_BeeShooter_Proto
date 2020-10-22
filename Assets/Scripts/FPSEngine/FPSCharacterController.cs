using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class FPSCharacterController : MonoBehaviour
{

    public Camera mainCamera;
    public Camera weaponCamera;
    
    public Transform cameraPosition;
    public Transform weaponPosition;
    
    [Header("Control Settings")]
    public float mouseSensitivity = 100.0f;
    public float playerSpeed = 5.0f;
    public float runningSpeed = 7.0f;
    public float jumpSpeed = 5.0f;
    public float maxFallSpeed = 10.0f;

    float _verticalSpeed = 0.0f;
    bool _isPaused = false;
    
    float _verticalAngle, _horizontalAngle;

    CharacterController _CharacterController;

    bool _grounded;
    float _groundedTimer;
    float _speedAtJump = 0.0f;

    public float Speed { get; private set; } = 0.0f;

    public bool LockControl { get; set; }
    public bool CanPause { get; set; } = true;

    public bool Grounded => _grounded;

    Dictionary<int, int> m_AmmoInventory = new Dictionary<int, int>();
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _isPaused = false;
        _grounded = true;
        
        mainCamera.transform.SetParent(cameraPosition, false);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localRotation = Quaternion.identity;
        _CharacterController = GetComponent<CharacterController>();
        _verticalAngle = 0.0f;
        _horizontalAngle = transform.localEulerAngles.y;
    }

    void Update()
    {      
        bool wasGrounded = _grounded;
        bool loosedGrounding = false;
        
        loosedGrounding = GroundedUpdate();

        Speed = 0;
        Vector3 move = Vector3.zero;
        if (!_isPaused && !LockControl)
        {
            
            if (_grounded && Input.GetButtonDown("Jump"))
            {
                loosedGrounding = Jump();
            }
            
            bool running = Input.GetButton("Debug Multiplier");
            float actualSpeed = running ? runningSpeed : playerSpeed;

            if (loosedGrounding)
            {
                _speedAtJump = actualSpeed;
            }

            // Move around with WASD
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (move.sqrMagnitude > 1.0f)
                move.Normalize();

            float usedSpeed = _grounded ? actualSpeed : _speedAtJump;
            
            move = move * usedSpeed * Time.deltaTime;            
            move = transform.TransformDirection(move);
            _CharacterController.Move(move);
            
            // Turn player
            float turnPlayer =  Input.GetAxis("Mouse X") * mouseSensitivity;
            _horizontalAngle = _horizontalAngle + turnPlayer;

            if (_horizontalAngle > 360) _horizontalAngle -= 360.0f;
            if (_horizontalAngle < 0) _horizontalAngle += 360.0f;
            
            Vector3 currentAngles = transform.localEulerAngles;
            currentAngles.y = _horizontalAngle;
            transform.localEulerAngles = currentAngles;

            // Camera look up/down
            var turnCam = -Input.GetAxis("Mouse Y");
            turnCam = turnCam * mouseSensitivity;
            _verticalAngle = Mathf.Clamp(turnCam + _verticalAngle, -89.0f, 89.0f);
            currentAngles = cameraPosition.transform.localEulerAngles;
            currentAngles.x = _verticalAngle;
            cameraPosition.transform.localEulerAngles = currentAngles;
            Speed = move.magnitude / (playerSpeed * Time.deltaTime);

        }

        // Fall down / gravity
        _verticalSpeed = _verticalSpeed - maxFallSpeed * Time.deltaTime;
        if (_verticalSpeed < - maxFallSpeed)
            _verticalSpeed = - maxFallSpeed; // max fall speed
        
        var verticalMove = new Vector3(0, _verticalSpeed * Time.deltaTime, 0);
        var flag = _CharacterController.Move(verticalMove);
        if ((flag & CollisionFlags.Below) != 0)
            _verticalSpeed = 0;


        // Between Frame comparisons
        if (!wasGrounded && _grounded)
        {
            Landed();
        }

    }

    public void DisplayCursor(bool display)
    {
        _isPaused = display;
        Cursor.lockState = display ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = display;
    }

    private bool Jump()
    {
        _verticalSpeed = jumpSpeed;
        _grounded = false;

        return true;

    }

    private void Landed()
    {



    }

    private bool GroundedUpdate()
    {
        bool loosedGrounding = false;

        if (!_CharacterController.isGrounded)
        {
            if (_grounded)
            {
                _groundedTimer += Time.deltaTime;
                if (_groundedTimer >= 0.5f)
                {
                    loosedGrounding = true;
                    _grounded = false;
                }
            }
        }
        else
        {
            _groundedTimer = 0.0f;
            _grounded = true;
        }

        return loosedGrounding;
    }

}
