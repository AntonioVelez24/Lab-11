using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    private Rigidbody _rigidbody;
    private float xDirection;
    private float zDirection;
    [SerializeField] private Material fireMaterial;
    [SerializeField] private Material plantMaterial;
    [SerializeField] private Material waterMaterial;
    private Material currentMaterial;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        currentMaterial = fireMaterial;
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(speed * xDirection, _rigidbody.velocity.y, speed * zDirection);
    }
    public void ReadMovementX(InputAction.CallbackContext context)
    {
        xDirection = context.ReadValue<float>();
    }
    public void ReadMovementZ(InputAction.CallbackContext context)
    {
        zDirection = context.ReadValue<float>();
    }
    public void ReadShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Renderer>().material = currentMaterial;
            Destroy(bullet, 2f);
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            currentMaterial = fireMaterial;
        }
        if (other.CompareTag("Plant"))
        {
            currentMaterial = plantMaterial;
        }
        if (other.CompareTag("Water"))
        {
            currentMaterial = waterMaterial;
        }
    }
}