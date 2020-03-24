using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform playerTransform;
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - playerTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = playerTransform.position.x + offsetX;

        transform.position = position;
    }
}
