using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridResetter : MonoBehaviour
{
    public Vector2 startPos = new Vector2(-17f, 8.5f);
    public string tag = "LineGrid";

    public float timer = 5f;
    private List<GameObject> _objects = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnNewLine", timer / 2f, timer);
    }

    private void SpawnNewLine()
    {
        if (_objects.Count < 1) return;
        var gameObject = _objects.First();
        gameObject.SetActive(true);
        _objects.Remove(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals(tag)) return;
        other.gameObject.SetActive(false);
        other.transform.localPosition = startPos;
        var gridObject = other.GetComponent<GridObject>();
        var scaler = other.GetComponent<Scaler>();
        if (gridObject != null)
        {
            gridObject.currentSpeed = GridObject.speed;
        }

        if (scaler != null)
        {
            other.transform.localScale = new Vector2(1f, 1f);
        }

        _objects.Add(other.gameObject);
    }
}