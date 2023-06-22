using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TestMovement : MonoBehaviour
{


    Rigidbody rg;

    Transform tr;

    Animator animator;


    [SerializeField]
    float moveSpeed;

    private Vector2 movementInput;
    private bool jumped;
    private bool basicAttacked;
    private bool heavyAttacked;

    [SerializeField]
    GameObject basicAttackObject;

    [SerializeField]
    Vector3 basicAttackCorrectionVector;
    [SerializeField]
    float basicAttackTime;
    [SerializeField]
    float basicAttackAnimationTime;
    [SerializeField]
    GameObject heavyAttackObject;
    [SerializeField]
    Vector3 heavyAttackCorrectionVector;

    [SerializeField]
    float heavyAttackTime;
    [SerializeField]
    float heavyAttackAnimationTime;
    [SerializeField]


    float jumpCount = 0;
    void Awake()
    {
        tr = this.transform;
        rg = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnJumped(InputAction.CallbackContext ctx) => jumped = true;

    public void OnBasicAttack(InputAction.CallbackContext ctx) => basicAttacked = true;
    public void OnHeavyAttack(InputAction.CallbackContext ctx) => heavyAttacked = true;


    private bool invoked;

    void Update()
    {

        //as the objects are supposed to only move along one axis, but the controller gives us values for two and the functions wants to have three some tricking is required
        tr.Translate(new Vector3(0, 0, movementInput.x) * moveSpeed * Time.deltaTime, Space.Self);
        animator.SetFloat("Walking", Mathf.Abs(movementInput.x));


        if (jumped && !invoked)
        {
            Jump();
            jumped = false;
        }

        if (basicAttacked && !invoked)
        {

            invoked = true;
            animator.SetTrigger("BasicAttack");
            Invoke("BasicAttackMethod", basicAttackTime);
            StartCoroutine(AnimationEnd("BasicAttack", basicAttackAnimationTime));
        }

        if (heavyAttacked && !invoked)
        {

            invoked = true;
            animator.SetTrigger("HeavyAttack");
            HeavyAttackMethod();
            Invoke("HeavyAttackMethod", heavyAttackTime);
            StartCoroutine(AnimationEnd("HeavyAttack", heavyAttackAnimationTime));
        }
        heavyAttacked = false;
        basicAttacked = false;
        jumped = false;
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
        Instantiate(basicAttackObject, tr.position + basicAttackCorrectionVector, tr.rotation);
        basicAttacked = false;
    }   

    void HeavyAttackMethod()
    {
        Instantiate(heavyAttackObject, tr.position + heavyAttackCorrectionVector, tr.rotation);
        heavyAttacked = false;
    }

    IEnumerator AnimationEnd(string pAnimation, float pTime)
    {
        yield return new WaitForSeconds(pTime);
        invoked = false;
        animator.ResetTrigger(pAnimation);
        //setting jump to false to prevent weird behavior
        jumped = false;
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
