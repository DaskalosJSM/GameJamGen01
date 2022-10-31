using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
   [SerializeField] float Velocidad;
   [SerializeField] Vector3 Direccion;
    void Update()
    {
        this. transform.Translate(Direccion* Time.deltaTime*Velocidad);
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
