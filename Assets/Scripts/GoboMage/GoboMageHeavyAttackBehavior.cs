using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoboMageHeavyAttackBehavior : MonoBehaviour
{

    public int splitNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(splitNumber<5){
            StartCoroutine(Split());
            StartCoroutine(Split());
        }
    }

    IEnumerator Split()
    {
        yield return new WaitForSeconds(0.15f);
       GameObject o = Instantiate(this.gameObject,transform.forward *2  + transform.position,Quaternion.LookRotation(transform.forward ,transform.up+ new Vector3(Random.Range(-10,10),Random.Range(-20,20),Random.Range(-2,2))));
       o.GetComponent<GoboMageHeavyAttackBehavior>().splitNumber = this.splitNumber + 1;
    }

    void Update()
    {
        transform.Rotate(new Vector3(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10)));
    }
}
