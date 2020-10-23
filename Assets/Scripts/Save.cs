using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    [Header("Save Score")]
    public Text scoreText;

    public InputField nameScore;

    public Button saveButton;

    private Score score = new Score();

    private void Start()
    {
        saveButton.onClick.AddListener(SaveScore);
    }
    private void SaveScore()
    {

        score.score = GameManager.Instance.Score.ToString();
        score.name = nameScore.text;
        //PlayerPrefs.SetString("Score", GameManager.Instance.Score + nameScore.text);
        print("Saving");

        string scoreJson = JsonUtility.ToJson(score);
        Debug.Log(scoreJson);
        //File.WriteAllText(Application.persistentDataPath, scoreJson);
        Debug.Log(Path.Combine(Application.persistentDataPath, "Leaderboard"));
        SceneManager.LoadScene(0);
    }




    public class Score
    {
        public string score, name;
    }






}
