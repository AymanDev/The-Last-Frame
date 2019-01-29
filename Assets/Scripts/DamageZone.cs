using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage = 1;

    private bool acted;
    private Coroutine _coroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Player")) return;
        var playerController = other.GetComponent<PlayerController>();
        playerController.Damage(damage);
        acted = true;
        _coroutine = StartCoroutine(ProcessTrigger(playerController, 2f));
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (!other.tag.Equals("Player")) return;
        if (acted) return;
        var playerController = other.GetComponent<PlayerController>();
        acted = true;
        _coroutine = StartCoroutine(ProcessTrigger(playerController, 2f));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator ProcessTrigger(PlayerController playerController, float delay)
    {
        yield return new WaitForSeconds(delay);
        acted = false;
        playerController.Damage(damage);
    }
}