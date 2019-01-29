using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Car"))
        {
            var wall = other.GetComponent<Wall>();
            wall.carMode = true;
        }

        if (!other.tag.Equals("CamRemovable")) return;
        Destroy(other.gameObject);
    }
}