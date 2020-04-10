using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class AngkaLvlController : MonoBehaviour
    {
        private GameObject lvl1Btn, lvl2Btn, lvl3Btn;
        private void Start()
        {
            initializeButton();
            controlInteractableButton();
            setStarByPlayerPrefs();
            Debug.Log(PlayerPrefs.GetInt("AngkaLvl1Star"));
        }

        private void Update()
        {
            
        }

        void initializeButton()
        {
            lvl1Btn = gameObject.transform.Find("Lvl1").gameObject;
            lvl2Btn = gameObject.transform.Find("Lvl2").gameObject;
            lvl3Btn = gameObject.transform.Find("Lvl3").gameObject;

            lvl2Btn.GetComponent<Button>().interactable = false;
            lvl3Btn.GetComponent<Button>().interactable = false;
        }

        void controlInteractableButton()
        {
            //Name og get Int must same as scene Name
            if (PlayerPrefs.GetInt("AngkaLvl1") == 1)
            {
                lvl1Btn.GetComponent<Button>().interactable = true;
            } 
            if (PlayerPrefs.GetInt("AngkaLvl2") == 1)
            {
                lvl2Btn.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("AngkaLvl3") == 1)
            {
                lvl3Btn.GetComponent<Button>().interactable = true;
            }
        }
        void setStarByPlayerPrefs()
        {
            GameObject DummyBtn;
            for (int i = 1; i < 4; i++)
            {
                DummyBtn = gameObject.transform.Find("Lvl" + i).gameObject;
                setInActiveStar(DummyBtn);
                setActiveStar(PlayerPrefs.GetInt("AngkaLvl" + i + "Star"), DummyBtn);
            }
        }

        public void setActiveStar(int starGet, GameObject obj)
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