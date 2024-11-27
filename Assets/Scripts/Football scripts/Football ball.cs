using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Footballball : MonoBehaviour, IForceApplier
{
    // A�ade una variable fuerza a la pelota
  public float Force = 10f;
 private Rigidbody _rigidbody;
   private bool _isDirty = false;

  private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyForce(Vector3.forward, Force);
            _isDirty = true;
        }

        if (_isDirty)
        {
            // Actualizar solo si hubo cambios en la posici�n
            _rigidbody.velocity = Vector3.zero;
            _isDirty = false;
        }
    }
  // M�todo de la interfaz IForceApplier
    public void ApplyForce(Vector3 direction, float force)
    {
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }



}
