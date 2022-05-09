using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEditor;

using UnityEngine;


public class MainDataManager : MonoBehaviour
{
    public static MainDataManager Instance;
    public string userName;
    public int highScore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CheckHighScore(int currentScore)
    {
        // Checks if current score is higher then highscore
        if (currentScore > highScore) { highScore = currentScore; }
    }

    // Saving data on sessions
    // This class will have the variables which need to be saved
    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int highScore;
    }

    public void StartGame()
    {
        // The path where the json is stored
        string path = Application.persistentDataPath + "savefile.json";
        
        // if the file exists then
        // convert the json path to the SaveData class type
        // reassign the old values to userName & highScore variables
        if (File.Exists(path))
        {
            string jsonText = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonText);
            
            userName = data.userName;
            highScore = data.highScore;

            Debug.Log("Game Started Data LOADED: ");
            Debug.Log(data.userName);
            Debug.Log(data.highScore);

        } 
    }

    public void DataUpload()
    {
        // Creating a new version of SaveData
        // Declaring the variables with real values
        SaveData data = new SaveData();
        data.userName = userName;
        data.highScore = highScore;

        Debug.Log("Game Ended Data SAVED: ");
        Debug.Log(data.userName);
        Debug.Log(data.highScore);

        // Converting data values to json
        string jsonText = JsonUtility.ToJson(data);
        // Writing the json file on hard disk
        File.WriteAllText(Application.persistentDataPath + "savefile.json", jsonText);
    }

    public void EndGame()
    {

        DataUpload();


# if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else

        Application.Quit();
#endif

    }
}
