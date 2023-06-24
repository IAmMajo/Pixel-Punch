using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{

    [SerializeField]
    int maxHealthPoints;

    int currentHealthPoints;

    bool iFrames;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }

    void OnTriggerEnter(Collider e)
    {
        
        if (e.gameObject.tag == "Attack" && e.gameObject.GetComponent<AttackScript>().creator != this.gameObject && !iFrames)
        {
            Debug.Log(currentHealthPoints);
            currentHealthPoints = currentHealthPoints - e.gameObject.GetComponent<AttackScript>().damage;
            iFrames = true;
            StartCoroutine(resetIFrames());
        }
    }

    IEnumerator resetIFrames()
    {
        yield return new WaitForSeconds(0.01f);
        iFrames = false;
    }
}
