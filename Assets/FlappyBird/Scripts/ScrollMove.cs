using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMove : MonoBehaviour {
	public float SpeedFactor;
	public int MoveDistance;
	public float BeginX;

	// Use this for initialization
	void Start () {
		BeginX = transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(SpeedFactor == 0f) return;
		
		transform.Translate(Vector3.left * SpeedFactor * Time.deltaTime);
		var temp = transform.localPosition;
		var clampX = SpeedFactor > 0 ? BeginX - Mathf.Repeat(BeginX - temp.x,MoveDistance) : Mathf.Repeat(temp.x - BeginX,MoveDistance) + BeginX;
		var vec = new Vector3(clampX,temp.y,temp.z);
		transform.localPosition = vec;
	}
}
