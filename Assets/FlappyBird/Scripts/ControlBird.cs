using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBird : MonoBehaviour {
    public float force = 1f;
    Vector2 speed = new Vector3(0, -9.8f, 0);

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space))
        {
            speed = new Vector3(0, 20f, 0);
        }

        speed = Vector3.Lerp(speed, new Vector3(0, -9.8f, 0), Time.deltaTime);

        transform.Translate(speed * force);
	}
}
