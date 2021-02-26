using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Vector2 offset;
    private Vector3 newPos;

    private void Start()
    {
        newPos = new Vector3(0, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        newPos.x = player.position.x + offset.x;
        newPos.y = player.position.y + offset.y;
        transform.position = newPos;
    }
}
