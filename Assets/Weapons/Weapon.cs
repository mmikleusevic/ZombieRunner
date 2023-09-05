using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] InputAction _fire;
    [SerializeField] Camera _FPCamera;
    [SerializeField] float _range = 100f;

    private void Update()
    {
        Debug.Log(_fire.ReadValue<float>());
        bool isActive = _fire.ReadValue<float>() > 0.5;

        if (isActive)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out hit, _range);

        Debug.Log("thing that was hit: " + hit.transform.name);
    }

    void OnEnable()
    {
        _fire.Enable();
    }

    void OnDisable()
    {
        _fire.Disable();
    }
}
