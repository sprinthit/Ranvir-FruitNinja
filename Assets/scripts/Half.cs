using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Half : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;


    private void slice(Vector3 direction, Vector3 position, float force)
    {
        FindObjectOfType<GameManager>().IncreaseScore();
        FindObjectOfType<GameManager>().GoldScore();


        whole.SetActive(false);
        sliced.SetActive(true);

        fruitCollider.enabled = false;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody slice in slices)
        {
            slice.velocity = fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<Combo>().Count();
            FindObjectOfType<Combo3X>().Count();
            Blade blade = other.GetComponent<Blade>();
            slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
       
    }

    private void Awake()
    {
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
    }

   
   
}
