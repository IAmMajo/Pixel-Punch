using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField]
    public int damage;
    [SerializeField]
    float lifetime;

    [SerializeField]
    public string casterTag; 

    void Awake(){
        Destroy(this.gameObject, lifetime);
    }
}
