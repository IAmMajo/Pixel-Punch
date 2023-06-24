using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoboMageBasicAttackBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(Random.Range(-2f, 2f), Random.Range(-1f, 1f), 0));
        transform.position = transform.position + transform.forward*0.1f;
    }
}
