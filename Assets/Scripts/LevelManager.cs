using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
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
    }

    private void OnDisable()
    {
        PlayerController.gameOver -= GameOver;
    }
}
