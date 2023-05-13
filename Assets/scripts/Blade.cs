using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    private bool slicing;


    public Vector3 direction { get; private set; }
    public float minSliceVelocity = 0.01f;
    public float sliceForce = 5f;

    private void Awake()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();

    }
    private void OnEnable()
    {
        stopSlicing();

    }
    private void OnDisable()
    {
        stopSlicing();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {

            stopSlicing();
        }
        else if (slicing)
        {
            continueSlicing();
        }
    }
    private void startSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        transform.position = newPosition;

        slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }
    private void stopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }
    private void continueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }

}
