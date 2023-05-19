using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpPlayer : MonoBehaviour
{
    [SerializeField]
    Vector3 position = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        other.transform.position = position;
    }
}
