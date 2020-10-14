using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControoler : MonoBehaviour
{
        public void Startgame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
