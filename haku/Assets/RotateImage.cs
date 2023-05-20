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
    private Quaternion startRotation;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start() {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && !isRotating) {
            StartCoroutine(RotateToDestination());
        }
    }

    IEnumerator RotateToDestination()
    {
        isRotating = true;

        targetRotation = startRotation * Quaternion.Euler(0f, 0f, targetAngle);

        float t = 0f;
        while (t < 1f) {
            t += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        // Update the startRotation for the next rotation
        startRotation = transform.rotation;

        isRotating = false;
    }
}
