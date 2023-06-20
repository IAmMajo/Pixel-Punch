using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{

    [SerializeField]
    int HealthPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider e)
    {
        if (e.gameObject.tag == "Attack")
        {
            HealthPoints = HealthPoints - e.gameObject.GetComponent<AttackDamage>().damage;
        }
    }
}
