using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    [SerializeField] float GRAVITY_FORCE = .78f;
    private float m_GravityRadius;

    private void Start()
    {
        m_GravityRadius = GetComponent<SphereCollider>().radius;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out var rb))
        {
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_FORCE * Time.smoothDeltaTime);
            Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
        }
    }
}
