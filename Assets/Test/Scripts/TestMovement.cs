using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TestMovement : MonoBehaviour
{

    [SerializeField]
    Rigidbody rg;
    [SerializeField]
    Transform tr;

    TestInput controls;
    InputAction jumpGamepad;
    InputAction moveGamepad;
    InputAction moveLeftKey;
    InputAction moveRightKey;
    InputAction jumpKey;

    [SerializeField]
    float moveSpeed;

    float jumpCount = 0;
    void Awake()
    {
        controls = new TestInput();
        //gamepad
        jumpGamepad = controls.Gameplay.Jump;
        moveGamepad = controls.Gameplay.Move;
        //keyboard
        moveLeftKey = controls.Gameplay.MoveLeftKey;
        moveRightKey = controls.Gameplay.MoveRightKey;
        jumpKey = controls.Gameplay.JumpKey;
    }

    void Update()
    {
        //checks if the jump button gets pressed and if you jumped less than two times, as you are not supossed to fly but a double jump is common for such games
        if ((jumpGamepad.triggered || jumpKey.triggered) && jumpCount < 2)
        {
            Jump();
            jumpCount++;
        }
        //as the objects are supposed to only move along one axis, but the controller gives us values for two and the functions wants to have three some tricking is required
        Debug.Log(moveGamepad.ReadValue<Vector2>().x * -1f);
        tr.Translate(new Vector3(0, 0, moveGamepad.ReadValue<Vector2>().x * -1f) * moveSpeed * Time.deltaTime, Space.Self);
        if (moveLeftKey.IsPressed())
        {
            tr.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime, Space.Self);
        }else if(moveRightKey.IsPressed()){
            tr.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime, Space.Self);
        }
    }

    void Jump()
    {
        //divison trough jumpcount to make second jump smaller
        rg.AddForce(new Vector3(0, 10 / (jumpCount * 2 + 1), 0), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision e)
    {
        //checks if collision happens with a Object that is tagged as Ground and that is lower to prevent wall jumps
        if (e.gameObject.tag == "Ground" && e.gameObject.transform.position.y < transform.position.y)
        {
            jumpCount = 0;
        }
    }

    //nessecary methods for using Input Actions
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
