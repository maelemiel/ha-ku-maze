using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaikuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.score += 1;
        Destroy(gameObject);
    }
}
