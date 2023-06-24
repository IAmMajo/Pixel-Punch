using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoboAlchemistBasicAttackBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x*2,2,0));
    }

    void Update()
    {
        transform.Rotate(new Vector3(0.1f,0.1f,0.1f));
    }
}
