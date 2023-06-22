using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{

    [SerializeField]
    int maxHealthPoints;

    int currentHealthPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }

    void OnTriggerEnter(Collider e)
    {
        if (e.gameObject.tag == "Attack" && e.gameObject.GetComponent<AttackDamage>().casterTag != this.tag)
        {
            currentHealthPoints = currentHealthPoints - e.gameObject.GetComponent<AttackDamage>().damage;
        }
    }
}
