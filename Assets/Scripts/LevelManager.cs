using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text LifeText;
    public Text RoundText;
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GetComponent<Animator>().SetTrigger("FadeIn");
    }

    private void OnEnable()
    {
        PlayerController.gameOver += GameOver;
        GameManager.onLifeChange += updateLife;
        GameManager.onRoundChange += updateRound;
    }

    private void OnDisable()
    {
        PlayerController.gameOver -= GameOver;
        GameManager.onLifeChange -= updateLife;
        GameManager.onRoundChange -= updateRound;
    }

    public void updateLife(int life)
    {
        LifeText.text = "X" + life;
    }

    public void updateRound(int round)
    {
        RoundText.text = "Round: " + round;
    }
}
