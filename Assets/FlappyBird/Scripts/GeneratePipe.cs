using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePipe : MonoBehaviour
{
    public GameObject PipeTemplate;
    public GameObject SpawnFlag;
    public GameObject ScoreTemplate;
    public Vector2 SpawnInterval;
    public Vector2 TopVertivalInterval;
    public bool SpawnScore;
    public float ScoreHeight;

    public float TimeSpan;
    public float LastCoordX;
    public float CurSpawnInterval;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan += Time.deltaTime;

        if (TimeSpan >= CurSpawnInterval)
        {
            Generate();
            TimeSpan = 0;
        }
    }

    void Generate()
    {
        var obj = GameObject.Instantiate(PipeTemplate);

        var coordX = transform.InverseTransformPoint(SpawnFlag.transform.position).x;
        var verticalField = TopVertivalInterval;
        var coordY = Random.Range(verticalField.x, verticalField.y);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = new Vector3(coordX, coordY, 0);
        obj.transform.localEulerAngles = Vector3.zero;
        obj.transform.localScale = Vector3.one;

        CurSpawnInterval = Random.Range(SpawnInterval.x, SpawnInterval.y);
        LastCoordX = coordX;

        if (SpawnScore)
        {
            var score = Random.Range(1, 11);
            GenerateScore(coordX, coordY, score);

        }
    }

    void GenerateScore(float x, float y, int score)
    {
        var obj = GameObject.Instantiate(ScoreTemplate);

        obj.transform.SetParent(transform);
        obj.transform.localPosition = new Vector3(x, y + ScoreHeight, 0);
        obj.transform.localEulerAngles = Vector3.zero;
        obj.transform.localScale = Vector3.one;
    }

    public void DestroyAllPipes()
    {
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
