using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGroundHit : MonoBehaviour
{
    void OnTriggerEnter(Collider e){
        if (e.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject,0f);
        }
    }
}
