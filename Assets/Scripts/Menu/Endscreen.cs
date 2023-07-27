using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Endscreen : MonoBehaviour
{
[SerializeField]
Sprite[] gobos;
    public int winner;
    public int winnerGobo;
    public int loserGobo;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("PlayerWonTextBox").GetComponent<TextMeshProUGUI>().text =
            "Player " + winner + " won";
            GameObject.FindWithTag("WinnerScreen").GetComponent<Image>().sprite = gobos[winnerGobo];
            GameObject.FindWithTag("LooserScreen").GetComponent<Image>().sprite = gobos[loserGobo];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
