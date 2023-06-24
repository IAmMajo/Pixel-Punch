using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMovement : MonoBehaviour
{


    Rigidbody rg;

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

    SpecialCharacterActions spChAc;

    [SerializeField]
    int charactorSelector;

    float jumpCount = 0;


    void Awake()
    {
        rg = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
        switch (charactorSelector)
        {
            case 0:
                spChAc = this.GetComponent<SpecialActionsGoboBase>();
                break;

            default:
                Debug.Log("Ungültiger Character Selector");
                spChAc = null;
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnJumped(InputAction.CallbackContext ctx) => jumped = ctx.performed;

    public void OnBasicAttack(InputAction.CallbackContext ctx) => basicAttacked = ctx.performed;
    public void OnHeavyAttack(InputAction.CallbackContext ctx) => heavyAttacked = ctx.performed;


    private bool invoked;

    void Update()
    {

        if (!invoked)
        {
            //as the objects are supposed to only move along one axis, but the controller gives us values for two and the functions wants to have three some tricking is required
            transform.Translate(new Vector3(movementInput.x * moveSpeed * Time.deltaTime, 0, 0), Space.World);
            animator.SetFloat("Walking", Mathf.Abs(movementInput.x));
            if (GetSign(movementInput.x) != 0)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(GetSign(movementInput.x), 0, 0), Vector3.up);
            }


            if (jumped)
            {
                Jump();
                jumped = false;
            }

            if (basicAttacked)
            {
                invoked = true;
                animator.SetTrigger("BasicAttack"); if (spChAc != null)
                {
                    spChAc.BasicAttackBehavior();
                }
                Invoke("BasicAttackMethod", basicAttackTime);
                StartCoroutine(AnimationEnd("BasicAttack", basicAttackAnimationTime));
            }

            if (heavyAttacked)
            {
                invoked = true;
                animator.SetTrigger("HeavyAttack");
                if (spChAc != null)
                {
                    spChAc.HeavyAttackBehavior();
                }
                Invoke("HeavyAttackMethod", heavyAttackTime);
                StartCoroutine(AnimationEnd("HeavyAttack", heavyAttackAnimationTime));
            }
        }

        heavyAttacked = false;
        basicAttacked = false;
        jumped = false;
    }

    int GetSign(float pValue)
    {
        if (pValue > 0) return 1;
        if (pValue < 0) return -1;
        return 0;
    }

    void Jump()
    {
        if (jumpCount <= 2)
        {
            //divison trough jumpcount to make second jump smaller
            rg.AddForce(new Vector3(0, 10 / (jumpCount + 1), 0), ForceMode.Impulse);
            jumpCount++;
        }

    }

    void BasicAttackMethod()
    {
        Vector3 correctionVectorCurrent = new Vector3(basicAttackCorrectionVector.x * GetSign(transform.rotation.y),
            basicAttackCorrectionVector.y,
            basicAttackCorrectionVector.z * GetSign(transform.rotation.y));
        GameObject attack = Instantiate(basicAttackObject, transform.position + correctionVectorCurrent,
            transform.rotation);
        attack.GetComponent<AttackScript>().creator = this.gameObject;
        attack.GetComponent<AttackScript>().correctionVector = correctionVectorCurrent;
        basicAttacked = false;
    }

    void HeavyAttackMethod()
    {
        Vector3 correctionVectorCurrent = new Vector3(heavyAttackCorrectionVector.x * GetSign(transform.rotation.y),
          heavyAttackCorrectionVector.y,
          heavyAttackCorrectionVector.z * GetSign(transform.rotation.y));
        GameObject attack = Instantiate(heavyAttackObject, transform.position + correctionVectorCurrent, transform.rotation);
        attack.GetComponent<AttackScript>().creator = this.gameObject;
         attack.GetComponent<AttackScript>().correctionVector = correctionVectorCurrent;
        heavyAttacked = false;
    }

    IEnumerator AnimationEnd(string pAnimation, float pTime)
    {
        yield return new WaitForSeconds(pTime);

        animator.ResetTrigger(pAnimation);
        invoked = false;
        //setting jump to false to prevent weird behavior
        jumped = false;
    }

    void OnCollisionEnter(Collision e)
    {
        //checks if collision happens with a Object that is tagged as Ground and that is lower to prevent wall jumps
        if (e.gameObject.tag == "Ground" && e.gameObject.transform.position.y < base.transform.position.y)
        {
            jumpCount = 0;
        }
    }
}
