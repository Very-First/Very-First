using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomScore : MonoBehaviour
{
    public Sprite[] sprites;
    public Image img;
    public int Score;
    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = sprites[Random.Range(0, sprites.Length)];
        Score = int.Parse(img.sprite.name.Substring("Score".Length));
    }
}
