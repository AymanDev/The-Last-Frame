using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = 2.5f;
    private float _offsetSpeed = 0.7f;

    private float _xStart;

    public bool carMode = false;

    private void Start()
    {
        _xStart = transform.position.x;
    }

    // Update is called once per frame
    private void Update()
    {
        if (carMode)
        {
            transform.Translate(transform.right * 0.25f);
            Invoke("Suicide", 5f);
            return;
        }

        _offsetSpeed = 0.7f * speed / 2.5f - 0.1f;

        transform.Translate(new Vector2(_xStart * _offsetSpeed, -speed) *
                            GameController.instance.gameSpeed * Time.deltaTime);
        //transform.localScale += new Vector3(scaleSpeed, scaleSpeed);
    }

    private void Suicide()
    {
        Destroy(gameObject);
    }
}