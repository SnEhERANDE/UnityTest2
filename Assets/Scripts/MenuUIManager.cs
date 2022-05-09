using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    string inputFieldText;

    private void Start()
    {
        MainDataManager.Instance.StartGame();
        inputField.GetComponent<TMP_InputField>().text = MainDataManager.Instance.userName;
    }

    public void StartGameClick()
    {
        inputFieldText = inputField.GetComponent<TMP_InputField>().text;
        MainDataManager.Instance.userName = inputFieldText;

        //Debug.Log("MenuScript " + MainDataManager.Instance.userName);
        MainDataManager.Instance.StartGame();
        if (MainDataManager.Instance.userName != "" && inputFieldText == "Player")
        {
            
            inputFieldText = MainDataManager.Instance.userName;
        } else if (inputFieldText != MainDataManager.Instance.userName)
        {
            MainDataManager.Instance.highScore = 0;
            MainDataManager.Instance.userName = inputFieldText;
        }
        SceneManager.LoadScene(1);
    }

    public void EndGameClick()
    {
        MainDataManager.Instance.EndGame();
    }
}
