using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject winText, scoreText, timeText, winUI;
    public int objectCount;
    public Vector2[] fixPosition;
    public static List<Vector2> listPosition;
    public static List<int> randomList;
    public static bool updated = false;
    
    //Score
    public static int score = 0;
    public int targetScore = 50;
    
    //Time
    private float currentTime=0f, startingTime=10f;
    void Start()
    {
        winUI.SetActive(false);
        scoreText.GetComponent<Text>().text = score.ToString();
        createListPosition();

        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Darat.locked && Air.locked && Udara.locked)
        {
            updated = true;
            Air.restart = true;
            Darat.restart = true;
            Udara.restart = true;
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
        if (currentTime <= 0)
        {
            if (score >= targetScore)
            {
                winUI.SetActive(true);
            }
            else
            {
                winText.GetComponent<Text>().text = "You Lose";
                winUI.SetActive(true);
            }
        }
    }
}
