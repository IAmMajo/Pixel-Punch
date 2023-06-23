using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoboBaseHeavyAttack : MonoBehaviour
{
    Transform pos;
    Vector3 correctionVector;
    void Start()
    {
        pos = this.GetComponent<AttackScript>().creator.transform;
        correctionVector = this.GetComponent<AttackScript>().correctionVector;
        Debug.Log(correctionVector);
    }

    void Update(){
        transform.position = pos.position + correctionVector;
    }
}
