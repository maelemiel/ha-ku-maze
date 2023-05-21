using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1f;
    [SerializeField]
    private float targetAngle = 90f;

    private bool isRotating = false;
    private bool isWhite = true;
    private Quaternion startRotation;
    private Quaternion targetRotation;

    private GameObject[] blackWalls;
    private GameObject[] whiteWalls;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
        blackWalls = GameObject.FindGameObjectsWithTag("BlackWall");
        whiteWalls = GameObject.FindGameObjectsWithTag("WhiteWall");
        SwitchWalls();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            StartCoroutine(RotateToDestination());
            SwitchWalls();
        }
    }

    IEnumerator RotateToDestination()
    {
        isRotating = true;

        targetRotation = startRotation * Quaternion.Euler(0f, 0f, targetAngle);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        // Update the startRotation for the next rotation
        startRotation = transform.rotation;

        isRotating = false;
    }

    private void SwitchWalls()
{
    if (isWhite)
    {
        foreach (GameObject blackWall in blackWalls)
        {
            blackWall.SetActive(true);
            SpriteRenderer wallRenderer = blackWall.GetComponent<SpriteRenderer>();
            if (wallRenderer != null)
            {
                wallRenderer.color = Color.white;
            }
        }
        foreach (GameObject whiteWall in whiteWalls)
        {
            whiteWall.SetActive(false);
        }
        isWhite = false;
    }
    else
    {
        foreach (GameObject blackWall in blackWalls)
        {
            blackWall.SetActive(false);
        }
        foreach (GameObject whiteWall in whiteWalls)
        {
            whiteWall.SetActive(true);
        }
        isWhite = true;
    }
}

}
