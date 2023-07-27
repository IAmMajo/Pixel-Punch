using System.Collections;
using TMPro;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    [SerializeField]
    int maxHealthPoints;

    [SerializeField]
    int totalRespawns;

    Vector3 initialPosition;
    Quaternion initialRotation;
    int currentHealthPoints;
    int currentRespawns;
    GameObject healthGameObject;
    bool iFrames;

    [SerializeField]
    Canvas winscreen;

    // Start is called before the first frame update
    void Start()
    {
        this.initialPosition = this.transform.position;
        this.initialRotation = this.transform.rotation;
        this.currentHealthPoints = this.maxHealthPoints;
        this.currentRespawns = this.totalRespawns;
        int taggedID = this.tag == "Player1" ? 1 : 2;
        if (taggedID == 1)
        {
            this.healthGameObject = GameObject.Find("Player 1 Health");
        }
        else
        {
            this.healthGameObject = GameObject.Find("Player 2 Health");
        }
    }

    void OnTriggerEnter(Collider e)
    {
        if (
            e.gameObject.tag == "Attack"
            && e.gameObject.GetComponent<AttackScript>().creator != this.gameObject
            && !this.iFrames
        )
        {
            this.onDamage(e.gameObject.GetComponent<AttackScript>().damage);
        }
    }

    void Update()
    {
        if (this.transform.position.y < -50)
        {
            this.onDamage(this.maxHealthPoints);
        }
    }

    void onDamage(int damage)
    {
        if (damage < this.currentHealthPoints)
        {
            this.currentHealthPoints -= damage;
            this.iFrames = true;
            StartCoroutine(this.resetIFrames());
        }
        else
        {
            this.currentHealthPoints = this.maxHealthPoints;

            if (this.currentRespawns == 1)
            {
                this.transform.position = this.initialPosition;
                endscreen();
            }
            else
            {
                this.transform.position = this.initialPosition;
                this.transform.rotation = this.initialRotation;
                this.currentRespawns--;
                this.iFrames = true;
                StartCoroutine(this.resetIFrames());
            }
        }
        this.healthGameObject.GetComponent<TextMeshProUGUI>().text =
            $"{this.currentHealthPoints} / {this.maxHealthPoints} Health\n"
            + $"{this.currentRespawns} / {this.totalRespawns} Respawns";
    }

    void endscreen()
    {
        //death
        Canvas ws = Instantiate(winscreen);
        Endscreen es = ws.GetComponent<Endscreen>();
        es.winner = this.tag != "Player1" ? 1 : 2;

        Hitable[] hitables = FindObjectsOfType<Hitable>();

        foreach (Hitable hitable in hitables)
        {
            if (hitable.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
            {
                es.loserGobo = checkGoboType(hitable.gameObject);
            }
            else
            {
                es.winnerGobo = checkGoboType(hitable.gameObject);
            }
        }
        Time.timeScale = 0;
    }

    int checkGoboType(GameObject pGO)
    {
        Debug.Log(pGO.name);
        switch (pGO.name)
        {
            case "GoboMage Variant(Clone)":
                return 1;
            case "GoboAlchemist Variant(Clone)":
                return 2;
            default:
                return 0;
        }
    }

    IEnumerator resetIFrames()
    {
        yield return new WaitForSeconds(0.01f);
        this.iFrames = false;
    }
}
