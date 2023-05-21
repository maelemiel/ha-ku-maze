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
    private bool hasTriggered = false; // New variable to track if haiku has been triggered

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
        if (!hasTriggered) // Check if haiku has not been triggered before
        {
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            gameManager.score += 1;
            displayText.text = haikuText.Replace("\\n", "<br>");
            displayText.gameObject.SetActive(true);
            displayActive = true;
            hasTriggered = true; // Set hasTriggered to true to prevent gaining points again
        }
    }
}
