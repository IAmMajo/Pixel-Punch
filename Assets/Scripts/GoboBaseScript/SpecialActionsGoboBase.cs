using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialActionsGoboBase : MonoBehaviour, SpecialCharacterActions
{
    Rigidbody rg;
    Transform tr;

    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        tr = this.transform;
    }

    public void BasicAttackBehavior() { }

    public void HeavyAttackBehavior()
    {

        StartCoroutine(StartJump());
        StartCoroutine(Dash());

    }

    IEnumerator StartJump()
    {
        yield return new WaitForSeconds(0.01f);
        rg.AddForce(new Vector3(2 * tr.forward.x, 2, 0)*6f, ForceMode.Impulse);
    }

    IEnumerator Dash()
    {
        yield return new WaitForSeconds(0.2f);
        rg.AddForce(tr.forward * 15f*1.5f, ForceMode.Impulse);
    }

   
}
