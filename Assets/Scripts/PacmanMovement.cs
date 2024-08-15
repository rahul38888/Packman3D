using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public float gravity = -9.8f;
    public float speed = 15f;

    CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = Vector3.ClampMagnitude(new Vector3(deltaX, 0, deltaZ), speed);

        if(movement.magnitude > 0)
            transform.forward = movement.normalized;

        movement.y = gravity;
        movement *= Time.deltaTime;

        controller.Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        GhostMovement ghost = other.GetComponent<GhostMovement>();
        if(ghost != null)
        {
            Debug.Log("Ghost trigger");
            GetComponent<ICanEat>().Hit();
        }
    }

}
