using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TestMovement : MonoBehaviour
{

    
    Rigidbody rg;
    
    Transform tr;


    [SerializeField]
    float moveSpeed;

    private Vector2 movementInput;
    private bool jumped;
    private bool basicAttacked;

    [SerializeField]
    GameObject BASICATTACKOBJECT;
    [SerializeField]
    Vector3 basicAttackCorrectionVector;

    float jumpCount = 0;
    void Awake()
    {
        tr = this.transform;
        rg = this.GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnJumped(InputAction.CallbackContext ctx) => jumped = true;

    public void OnBasicAttack(InputAction.CallbackContext ctx) => basicAttacked = true;


    void Update()
    {

        //as the objects are supposed to only move along one axis, but the controller gives us values for two and the functions wants to have three some tricking is required
        tr.Translate(new Vector3(0, 0, movementInput.x * -1f) * moveSpeed * Time.deltaTime, Space.Self);


        if (jumped)
        {
            Jump();
            jumped = false;
        }

        if (basicAttacked)
        {
            BasicAttackMethod();
            basicAttacked = false;
        }
    }

    void Jump()
    {
        if (jumpCount < 2)
        {

            //divison trough jumpcount to make second jump smaller
            rg.AddForce(new Vector3(0, 10 / (jumpCount * 2 + 1), 0), ForceMode.Impulse);
        }

    }

    void BasicAttackMethod()
    {
        Instantiate(BASICATTACKOBJECT, tr.position + basicAttackCorrectionVector, tr.rotation);
    }

    void OnCollisionEnter(Collision e)
    {
        //checks if collision happens with a Object that is tagged as Ground and that is lower to prevent wall jumps
        if (e.gameObject.tag == "Ground" && e.gameObject.transform.position.y < transform.position.y)
        {
            jumpCount = 0;
        }
    }
}
