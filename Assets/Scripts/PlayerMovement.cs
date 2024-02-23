using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private InputAction _chargeAction;

    private Rigidbody _rb;
    private PlayerRotation _playerRoatation;
    [SerializeField]
    private GameObject _arrow;
    [SerializeField]
    private GameObject _powerBar;

    private bool _isCharging = false;
    private bool _isGrounded = true;
    [SerializeField]
    private float _minSpeed = 1f;
    [SerializeField]
    private float _maxSpeed = 5f;
    [SerializeField]
    private float _timeToFullCharge = 50f;
    private float _elapsedTime;
    private float _percentageComplete;
    private float _speed = 0f;

    public float PercentageComplete => _percentageComplete;
    public bool IsCharging => _isCharging;


    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _chargeAction = _input.actions["ChargeStart"];

        _rb = GetComponent<Rigidbody>();
        _playerRoatation = GetComponent<PlayerRotation>();
    }

    private void OnEnable()
    {
        _chargeAction.performed += ChargeAction;
        _chargeAction.canceled += ReleaseAction;
    }

    private void OnDisable()
    {
        _chargeAction.performed -= ChargeAction;
        _chargeAction.canceled -= ReleaseAction;
    }

    private void Update()
    {
        if (_isCharging)
        {
            _elapsedTime += Time.deltaTime * _timeToFullCharge;
            _percentageComplete = _elapsedTime / _timeToFullCharge;
            _speed = Mathf.Lerp(_minSpeed, _maxSpeed, _percentageComplete);
        }
    }

    private void ChargeAction(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            _powerBar.SetActive(true);
            _playerRoatation.CanRotate = false;
            _isCharging = true;
            _arrow.SetActive(false);
        }
    }

    private void ReleaseAction(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            _isCharging = false;
            Vector3 dir = new Vector3(transform.forward.x, 1, transform.forward.z);
            _rb.AddForce(dir.normalized * _speed, ForceMode.Impulse);
            _isGrounded = false;
            _elapsedTime = 0;
            _percentageComplete = 0;
            _powerBar.SetActive(false);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")){
            _rb.velocity = Vector3.zero;
            _playerRoatation.CanRotate = true;
            _isGrounded = true;
            _arrow.SetActive(true);
        }
    }
}
