using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    Vector3 positionOffset;
    public float speed = 8f;
    Vector3 positionSpace;
    // Start is called before the first frame update
    void Start()
    {

        positionSpace = transform.position; //Keeps position of sphere on screen
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, Mathf.PingPong(Time.time * speed, 10), 0) + positionSpace;
    }
}
