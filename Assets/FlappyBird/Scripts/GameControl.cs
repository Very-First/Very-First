using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public ControlBird birdCtrl;
    public GeneratePipe TopSpawn;
    public GeneratePipe BottomSpawn;
    public Text ScoreText;
    public Text CongratulationText;

    public int CurScore;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        birdCtrl.gameObject.SetActive(true);
        TopSpawn.gameObject.SetActive(true);
        BottomSpawn.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(true);

        CongratulationText.gameObject.SetActive(false);
        gameObject.SetActive(false);

        birdCtrl.OnDead = ResetGame;
        birdCtrl.OnScore = AddScore;
    }

    public void ResetGame()
    {
        birdCtrl.transform.localPosition = Vector3.zero;
        TopSpawn.DestroyAllPipes();
        BottomSpawn.DestroyAllPipes();

        birdCtrl.gameObject.SetActive(false);
        TopSpawn.gameObject.SetActive(false);
        BottomSpawn.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(false);
        ScoreText.text = 0.ToString();

        CongratulationText.gameObject.SetActive(true);
        CongratulationText.text = string.Format("恭喜你获得{0}分", CurScore);

        gameObject.SetActive(true);
        CurScore = 0;
    }

    public void AddScore(int score)
    {
        CurScore += score;
        ScoreText.text = CurScore.ToString();
    }
}
