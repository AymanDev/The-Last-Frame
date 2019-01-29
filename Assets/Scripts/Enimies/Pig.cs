using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float speed = 0.1f;

    private float side = 1f;

    public float timer = 5f;

    private void Start()
    {
        if (transform.position.x > 0f)
            side = -1f;
        Invoke("Suicide", timer);
    }

    public void Suicide()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (side < 0f)
        {
            transform.localPosition -= transform.right * speed * Time.deltaTime;
        }
        else
        {
            transform.localPosition += side * transform.right * speed * Time.deltaTime;
        }
    }
}