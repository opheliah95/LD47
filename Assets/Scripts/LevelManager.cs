using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text UIText;
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Debug.Log("you are dead");
        GetComponent<Animator>().SetTrigger("FadeIn");
    }

    private void OnEnable()
    {
        PlayerController.gameOver += GameOver;
        GameManager.onLifeChange += updateLife;
    }

    private void OnDisable()
    {
        PlayerController.gameOver -= GameOver;
        GameManager.onLifeChange -= updateLife;
    }

    public void updateLife(int life)
    {
        UIText.text = "X" + life;
    }
}
