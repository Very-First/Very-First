using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlBird : MonoBehaviour
{
    public float force = 1f;
    public Rigidbody2D rigid;
    public UnityAction OnDead;
    public UnityAction<int> OnScore;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigid.AddForce(Vector2.up * force);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Debug.Log("GameOver!");
        if (OnDead != null) OnDead();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            RandomScore rs = other.GetComponent<RandomScore>();
            Debug.LogFormat("Got Score :{0}", rs.Score);
            if (OnScore != null) OnScore(rs.Score);
            Destroy(other.gameObject);
        }
    }
}
