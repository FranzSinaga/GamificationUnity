using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class KeaksaraanGameControl : MonoBehaviour
    { 
        [SerializeField] private GameObject scoreText, timeText, winUI;


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

            currentTime = startingTime;
            scene = SceneManager.GetActiveScene();
        }

        // Update is called once per frame
        void Update()
        {
            updateScore();
            addTime();
            checkWin();
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
}