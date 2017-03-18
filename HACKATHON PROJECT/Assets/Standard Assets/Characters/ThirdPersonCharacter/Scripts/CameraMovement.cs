using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        transform.position = player.transform.position;
        transform.forward = -player.transform.right;
    }
}
