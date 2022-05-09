using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MainScript " + MainDataManager.Instance.userName);

        scoreText.text = " Name : " + MainDataManager.Instance.userName + " Best Score : " + MainDataManager.Instance.highScore;
    }

    public void ExitGameClick() {
        MainDataManager.Instance.EndGame();
    }
    public void BackToMenuClick()
    {
        MainDataManager.Instance.DataUpload();
        SceneManager.LoadScene(0);
    }
}
