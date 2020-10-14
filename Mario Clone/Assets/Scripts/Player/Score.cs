using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text coinScoreText;
    private int scoreCount;
    private AudioSource audioManger;

    private void Awake()
    {
        audioManger = GetComponent<AudioSource>();
    }
    void Start()
    {
      
      
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == MyTag.COIN_TAG)
        {
            target.gameObject.SetActive(false);
            scoreCount++;

            coinScoreText.text = "X" + scoreCount;

            audioManger.Play();
        }
    }
}
