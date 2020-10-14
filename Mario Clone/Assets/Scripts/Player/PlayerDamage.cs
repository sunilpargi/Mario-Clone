using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private int lifeScoreCount;
    public Text lifeText;

    private bool canDamage;
    void Awake()
    {
        lifeScoreCount = 3;
        lifeText.text = "X" + lifeScoreCount;
        canDamage = true;
    }

    // Update is called once per frame
   public void DealDamage()
    {
        if (canDamage)
        {
            lifeScoreCount--;

            if (lifeScoreCount >= 0)
            {
                lifeText.text = "X" + lifeScoreCount;
            }

            if (lifeScoreCount == 0)
            {
                Time.timeScale = 0;
                StartCoroutine(ReloadScene());
            }

            canDamage = false;
            StartCoroutine(WaitForDamage());
        }

    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(3f);

        canDamage = true;
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(3f);

        SceneManager.LoadScene("GamePlay");

        Time.timeScale = 1;
    }
}
