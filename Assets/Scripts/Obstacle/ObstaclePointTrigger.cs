using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().AddPlayerPoints();
    }
}
