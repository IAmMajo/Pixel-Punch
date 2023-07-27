using System.Collections;
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

    GameObject pauseMenu;

    void Awake()
    {
        moveSpeed *= 1.2f;
        rg = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
        switch (charactorSelector)
        {
            case 0:
                spChAc = this.GetComponent<SpecialActionsGoboBase>();
                break;

            default:
                spChAc = null;
                break;
        }

        foreach (CanvasRenderer canvas in Resources.FindObjectsOfTypeAll<CanvasRenderer>())
        {
            if (canvas.CompareTag("PauseMenuOverlay"))
            {
                pauseMenu = canvas.gameObject;
                break;
            }
        }
        rg.useGravity = false;
         
         if (GetComponent<PlayerInput>().currentControlScheme != "Gamepad")
         {
             PlayerInput[] pIS = GetComponents<PlayerInput>();
             bool controllScheme1Used = false;
             foreach (PlayerInput pI in pIS)
             {
                 if (pI.currentControlScheme == "Keyboard")
                 {
                     controllScheme1Used = true;
                 }
             }
             if (!controllScheme1Used)
             {
                this.GetComponent<PlayerInput>()
                     .SwitchCurrentControlScheme("KeyboardArrow", Keyboard.current);
            }
             else
             {
                 this.GetComponent<PlayerInput>()
                     .SwitchCurrentControlScheme("Keyboard", Keyboard.current);
             }
         }
         Debug.Log(this.gameObject.name == "GoboBase Variant(Clone)");
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnJumped(InputAction.CallbackContext ctx) => jumped = ctx.performed;

    public void OnBasicAttack(InputAction.CallbackContext ctx) => basicAttacked = ctx.performed;

    public void OnHeavyAttack(InputAction.CallbackContext ctx) => heavyAttacked = ctx.performed;

    public void OnControllerLost(PlayerInput ctx)
    {
        PlayerInput[] pIS = GetComponents<PlayerInput>();
        bool controllScheme1Used = false;
        foreach (PlayerInput pI in pIS)
        {
            if (pI.currentControlScheme == "Keyboard")
            {
                controllScheme1Used = true;
            }
        }
        if (!controllScheme1Used)
        {
            this.GetComponent<PlayerInput>()
                .SwitchCurrentControlScheme("KeyboardArrow", Keyboard.current);
        }
        else
        {
            this.GetComponent<PlayerInput>()
                .SwitchCurrentControlScheme("Keyboard", Keyboard.current);
        }
    }

    public void OnControllerConnected(PlayerInput ctx)
    {
        ctx.SwitchCurrentControlScheme("Gamepad", Gamepad.current);
    }

    public void OnControllsChanged(PlayerInput ctx)
    {
    }

    bool paused = false;

    public void OnPause(InputAction.CallbackContext ctx)
    {
        foreach(InputDevice e in this.GetComponent<PlayerInput>().devices){
        }
        if (ctx.started)
        {
            paused = !paused;

            if (paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private bool invoked;

    void FixedUpdate()
    {
        rg.AddForce(-13.5f * Vector3.up);
        if (!invoked && Time.timeScale > 0)
        {
            //as the objects are supposed to only move along one axis, but the controller gives us values for two and the functions wants to have three some tricking is required
            transform.Translate(
                new Vector3(movementInput.x * moveSpeed * ((GetSign(jumpCount)*0.8f)+1f) * Time.deltaTime, 0, 0),
                Space.World
            );
            animator.SetFloat("Walking", Mathf.Abs(movementInput.x));
            if (GetSign(movementInput.x) != 0)
            {
                transform.rotation = Quaternion.LookRotation(
                    new Vector3(GetSign(movementInput.x), 0, 0),
                    Vector3.up
                );
            }

            if (jumped)
            {
                Jump();
                jumped = false;
            }

            if (basicAttacked)
            {
                invoked = true;
                animator.SetTrigger("BasicAttack");
                if (spChAc != null)
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
        if (pValue > 0)
            return 1;
        if (pValue < 0)
            return -1;
        return 0;
    }

    void Jump()
    {
        if (jumpCount < 2)
        {
            //divison trough jumpcount to make second jump smaller
            rg.AddForce(new Vector3(0, 22 / (jumpCount + 1), 0)*0.7f, ForceMode.Impulse);
            jumpCount++;
        }
    }

    void BasicAttackMethod()
    {
        Vector3 correctionVectorCurrent = new Vector3(
            basicAttackCorrectionVector.x * GetSign(transform.rotation.y),
            basicAttackCorrectionVector.y,
            basicAttackCorrectionVector.z * GetSign(transform.rotation.y)
        );
        GameObject attack = Instantiate(
            basicAttackObject,
            transform.position + correctionVectorCurrent,
            transform.rotation
        );
        attack.GetComponent<AttackScript>().creator = this.gameObject;
        attack.GetComponent<AttackScript>().correctionVector = correctionVectorCurrent;
        basicAttacked = false;
    }

    void HeavyAttackMethod()
    {
        Vector3 correctionVectorCurrent = new Vector3(
            heavyAttackCorrectionVector.x * GetSign(transform.rotation.y),
            heavyAttackCorrectionVector.y,
            heavyAttackCorrectionVector.z * GetSign(transform.rotation.y)
        );
        GameObject attack = Instantiate(
            heavyAttackObject,
            transform.position + correctionVectorCurrent,
            transform.rotation
        );
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

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        
    }

    void OnCollisionEnter(Collision e)
    {
        //checks if collision happens with a Object that is tagged as Ground and that is lower to prevent wall jumps
        if (
            e.gameObject.tag == "Ground"
            && e.gameObject.transform.position.y < base.transform.position.y
        )
        {
            jumpCount = 0;
        }
    }
}
