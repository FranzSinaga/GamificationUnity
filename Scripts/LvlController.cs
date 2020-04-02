using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DefaultNamespace
{
    public class LvlController : MonoBehaviour
    {
        private GameObject lvl1Btn, lvl2Btn, lvl3Btn;
        private void Start()
        {
            initializeButton();
            controlInteractableButton();
        }

        private void Update()
        {
            
        }

        void initializeButton()
        {
            lvl1Btn = gameObject.transform.Find("Lvl1").gameObject;
            lvl2Btn = gameObject.transform.Find("Lvl2").gameObject;
            lvl3Btn = gameObject.transform.Find("Lvl3").gameObject;
        }

        void controlInteractableButton()
        {
            //Name og get Int must same as scene Name
            if (PlayerPrefs.GetInt("HewanLvl1") == 1)
            {
                lvl1Btn.GetComponent<Button>().interactable = true;
            } 
            if (PlayerPrefs.GetInt("HewanLvl2") == 1)
            {
                lvl2Btn.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("HewanLvl3") == 1)
            {
                lvl3Btn.GetComponent<Button>().interactable = true;
            }
        }
    }
}