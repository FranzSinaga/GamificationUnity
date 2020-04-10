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
    public static int score = 0;
    public int targetScore = 50;
    
    //Time
    private float currentTime=0f, startingTime=120f;
    public int star1 = 50, star2 = 100, star3 = 150;
        private int starGet = 0;
    void Start()
    {
        score = 0;
        winUI.SetActive(false);
        setInActiveStar(winUI);
        scoreText.GetComponent<Text>().text = score.ToString();
        createListPosition();

        currentTime = startingTime;
        scene = SceneManager.GetActiveScene();

        Darat.locked = false;
        Darat2.locked = false;
        Darat3.locked = false;
        Air.locked = false;
        Udara.locked = false;

        Darat.restart = false;
        Darat2.restart = false;
        Darat3.restart = false;
        Air.restart = false;
        Udara.restart = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkLocked();
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
                getStarByScore();
                winUIStarGetUI(starGet, winUI);
            }
            else
            {
                winUI.GetComponentInChildren<Text>().text = "Kamu gagal";
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

    void checkLocked()
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
        } else if(Darat.locked && Darat2.locked && Darat3.locked && Air.locked && Udara.locked && scene.name == "HewanLvl3")
        {
            updated = true;
            Air.restart = true;
            Darat.restart = true;
            Udara.restart = true;
            Darat2.restart = true;
            Darat3.restart = true;
            createListPosition();
        }
    }

    void getStarByScore()
    {
        if (score >= star1 && score <star2)
        {
            starGet = 1;
        } 
        if (score >= star2 && score < star3)
        {
            starGet = 2;
        }
        if (score >= star3)
        {
            starGet = 3;
        }

        Debug.Log(starGet);
        if (PlayerPrefs.GetInt(scene.name+"Star") == 0 || starGet > PlayerPrefs.GetInt(scene.name+"Star"))
        {
            PlayerPrefs.SetInt(scene.name + "Star", starGet);
        }
    }

    void winUIStarGetUI(int star, GameObject obj)
    {
        if (starGet != 0)
        {
            if (starGet == 1)
            {
                obj.transform.Find("FillStar").Find("FillStar1").gameObject.SetActive(true);
            } else if (starGet == 2)
            {
                obj.transform.Find("FillStar").Find("FillStar1").gameObject.SetActive(true);
                obj.transform.Find("FillStar").Find("FillStar2").gameObject.SetActive(true);
            } else if (starGet == 3)
            {
                obj.transform.Find("FillStar").Find("FillStar1").gameObject.SetActive(true);
                obj.transform.Find("FillStar").Find("FillStar2").gameObject.SetActive(true);
                obj.transform.Find("FillStar").Find("FillStar3").gameObject.SetActive(true);
            }
        }
    }
    
    public void setInActiveStar(GameObject obj)
    {
        obj.transform.Find("FillStar").Find("FillStar1").gameObject.SetActive(false);
        obj.transform.Find("FillStar").Find("FillStar2").gameObject.SetActive(false);
        obj.transform.Find("FillStar").Find("FillStar3").gameObject.SetActive(false);
    }
}