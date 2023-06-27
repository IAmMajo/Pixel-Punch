using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    // Start is called before the first frame update
    void Start()
    {
        this.initialPosition = this.transform.position;
        this.initialRotation = this.transform.rotation;
        this.currentHealthPoints = this.maxHealthPoints;
        this.currentRespawns = this.totalRespawns;

        if (this.gameObject.GetComponent<PlayerInput>()?.user.id == 1)
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
        if
        (
            e.gameObject.tag == "Attack" &&
            e.gameObject.GetComponent<AttackScript>().creator != this.gameObject &&
            !this.iFrames
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
                this.gameObject.SetActive(false);
                this.healthGameObject.SetActive(false);
                this.currentRespawns = this.totalRespawns;
                SceneManager.LoadScene("Assets/Menus/SelectMenu.unity");

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
            $"{this.currentHealthPoints} / {this.maxHealthPoints} Health\n" +
            $"{this.currentRespawns} / {this.totalRespawns} Respawns";
    }

    IEnumerator resetIFrames()
    {
        yield return new WaitForSeconds(0.01f);
        this.iFrames = false;
    }
}
