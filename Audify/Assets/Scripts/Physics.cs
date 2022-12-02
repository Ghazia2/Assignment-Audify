using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    public Vector3 velocityVector;
    public float moveVelocity = 0;
    public float gravity = 9.8f;
    public float dampFactor = 0;
    private bool isLaunched = false;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            isLaunched = true;
        if (isLaunched)
        {
            // x1 = x0 + vt
            transform.position = transform.position + moveVelocity * Time.deltaTime * velocityVector;
            // change in velocity gives us acc. 
            velocityVector += gravity * Time.deltaTime * Vector3.down;
            OnCollison();
        }
    }

    private void OnCollison()
    {
        if (UnityEngine.Physics.Raycast(transform.position, velocityVector, out RaycastHit hit, 0.51f))
        {
            velocityVector = Vector3.Reflect(velocityVector, hit.normal);
            moveVelocity /= dampFactor;
        }
    }
}
