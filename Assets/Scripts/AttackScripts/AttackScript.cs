using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField]
    public int damage;
    [SerializeField]
    float lifetime;

    public GameObject creator; 
    public Vector3 correctionVector;

    void Awake(){
        Destroy(this.gameObject, lifetime);
    }
}
