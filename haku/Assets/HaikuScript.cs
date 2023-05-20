using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HaikuScript : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public string haikuText;
    private bool displayActive = false;

    void Start()
    {
        displayText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (displayActive && Input.GetKeyDown(KeyCode.Return))
        {
            displayText.gameObject.SetActive(false);
            displayActive = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.score += 1;
        displayText.text = haikuText.Replace("\\n", "<br>");
        displayText.gameObject.SetActive(true);
        displayActive = true;
    }
}
