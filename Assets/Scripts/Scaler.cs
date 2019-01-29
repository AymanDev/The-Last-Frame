using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{

	public float scaleSpeed = 0.1f;

	private void Update () {
		transform.localScale += new Vector3(scaleSpeed, scaleSpeed) * Time.deltaTime;
	}
}
