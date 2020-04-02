using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject scoreText, timeText, winUI;
    public int objectCount;
    public Vector2[] fixPosition;
    public static List<Vector2> listPosition;
    public static List<int> randomList;
    public static bool updated = false;


    private Scene scene;
    //Score
    public static int score = 50;
    public int targetScore = 50;
    
    //Time
    private float currentTime=0f, startingTime=100f;
    void Start()
    {
        winUI.SetActive(false);
        scoreText.GetComponent<Text>().text = score.ToString();
        createListPosition();

        currentTime = startingTime;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Darat.locked && Air.locked && Udara.locked && scene.name == "HewanLvl1")
        {
            updated = true;
            Air.restart = true;
            Darat.restart = true;
            Udara.restart = true;
            createListPosition();
        } else if(Darat.locked && Darat2.locked && Air.locked && Udara.locked && scene.name == "HewanLvl2")
        {
            updated = true;
            Air.restart = true;
            Darat.restart = true;
            Udara.restart = true;
            Darat2.restart = true;
            createListPosition();
        }

        updateScore();
        addTime();
        checkWin();
    }

    void createListPosition()
    {
        listPosition = new List<Vector2>();
        randomList = new List<int>();
        for (int i = 0; i < objectCount; i++)
        {
            listPosition.Add(fixPosition[i]);
            randomList.Add(i);
        }
    }

    void updateScore()
    {
        scoreText.GetComponent<Text>().text = score.ToString();
    }

    void addTime()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.GetComponent<Text>().text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    void checkWin()
    {
        string NextLevel = GetSceneNameFromScenePath(SceneUtility.GetScenePathByBuildIndex(scene.buildIndex + 1));
        if (currentTime <= 0)
        {
            if (score >= targetScore)
            {
                winUI.transform.Find("WinButtonLocation").gameObject.SetActive(true);
                winUI.transform.Find("LoseButtonLocation").gameObject.SetActive(false);
                if (NextLevel.Contains("Lvl"))
                {
                    PlayerPrefs.SetInt(NextLevel, 1);
                }
            }
            else
            {
                //winText.GetComponent<Text>().text = "You Lose";
                winUI.GetComponentInChildren<Text>().text = "You Lose";
                winUI.transform.Find("WinButtonLocation").gameObject.SetActive(false);
                winUI.transform.Find("LoseButtonLocation").gameObject.SetActive(true);
            }
            winUI.SetActive(true);
        }
    }
    
    private static string GetSceneNameFromScenePath(string scenePath)
    {
        // Unity's asset paths always use '/' as a path separator
        var sceneNameStart = scenePath.LastIndexOf("/", StringComparison.Ordinal) + 1;
        var sceneNameEnd = scenePath.LastIndexOf(".", StringComparison.Ordinal);
        var sceneNameLength = sceneNameEnd - sceneNameStart;
        return scenePath.Substring(sceneNameStart, sceneNameLength);
    }
}
