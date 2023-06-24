using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoboAlchemistBasicAttackBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x*12,7,0), ForceMode.Impulse);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0.1f,0.1f,0.1f));
    }

    void OnTriggerEnter(Collider e)
    {
        if (e.gameObject.tag == "Ground")
        {
            Instantiate(explosion,transform.position - new Vector3(0,1.5f,0),new Quaternion(0,0,0,1));
            Destroy(this.gameObject);
        }
    }
}
