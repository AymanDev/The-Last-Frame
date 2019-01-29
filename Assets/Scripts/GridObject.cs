using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public const float speed = 0.1f;
    public float currentSpeed = 0.2f;

    private void Update()
    {
        currentSpeed += speed;
        transform.Translate(new Vector3(0f, currentSpeed) *
                            GameController.instance.gameSpeed * -Time.deltaTime);
        // transform.localScale += new Vector3(scale, scale) * Time.deltaTime;
    }
}