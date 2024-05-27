using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Playerscript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float throwingForce;
    [SerializeField] private Camera camera;
    [SerializeField]private GameObject heldObject;

    private Vector3 heldPosition;
    private Vector3 direction;

    private bool directionRight = true;

    [SerializeField]private bool isGrounded;
    // false = left
    // true = right
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,120));
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed,0);
            directionRight = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed,0);
            directionRight = true;
        }

        //Fix
        if (Input.GetMouseButtonDown(1) && heldObject!= null)
        {
            var rigidbody = heldObject.GetComponent<Rigidbody2D>();
            var lookAtPos = Input.mousePosition;
            
            rigidbody.gravityScale = 1f;
            direction = camera.ScreenToWorldPoint(lookAtPos)-transform.position;
            rigidbody.AddForce(direction*throwingForce);
            heldObject = null; 
        }
        
        if (heldObject != null)
        {
            if (directionRight)
            {
                heldPosition = transform.position + transform.right/2;
            }
            else
            {
                heldPosition = transform.position + -transform.right/2;
            }

            heldObject.transform.position = heldPosition;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (other.gameObject.CompareTag("Ball") && heldObject == null)
            {
                heldObject = other.gameObject;
                heldObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
                
            }
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,direction);
    }
}
