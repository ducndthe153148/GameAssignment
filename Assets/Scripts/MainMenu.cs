using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Scene dashboard here
    public void GoToDashBoard()
    {
        SceneManager.LoadScene("DashboardScene");
    }

    // Scene excit here
    public void ExitGame()
    {
        Application.Quit();
    }
    private void OnDestroy()
    {
        Debug.Log("Destroy MenuScene");
    }
}
