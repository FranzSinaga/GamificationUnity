using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class BermainBuah : MonoBehaviour
    {
        public GameObject[] jawaban;
        public Sprite[] imageAnswer;
        public AudioClip[] audio;
        public GameObject voiceButton;
        private int answer;
        private bool reload;
        public bool isController;
        private void Start()
        {
            if (!isController)
            {
                int index = Random.Range(0,imageAnswer.Length);
                answer = index;
                setQuestion(index);
                setImage(index);
                voiceButton.GetComponentInChildren<Text>().text = answer.ToString();
                //checkBenar();
            }
        }

        private void Update()
        {
            if (reload)
            {
                int index = Random.Range(0,imageAnswer.Length);
                answer = index;
                setQuestion(index);
                setImage(index);
                //checkBenar();
                reload = false;
                voiceButton.GetComponentInChildren<Text>().text = answer.ToString();
            }
        }
        
        void setQuestion(int answerIndex)
        {
            voiceButton.GetComponent<AudioSource>().clip = audio[answerIndex];
        }
        void setImage(int index)
        {
            List<int> list = new List<int>();
            int i =0;
            int random;
            while (i < jawaban.Length)
            {
                random = Random.Range(0, imageAnswer.Length-1);
            
                if (!list.Contains(index))
                {
                    list.Add(index);
                    i++;
                    continue;
                } else if (!list.Contains(random))
                {
                    list.Add(random);
                    i++;
                    continue;
                }
            }
            list.Sort();
            for (int j = 0; j < jawaban.Length; j++)
            {
                jawaban[j].GetComponent<Image>().sprite = imageAnswer[list[j]];
                jawaban[j].transform.Find("Text").gameObject.GetComponent<Text>().text = list[j].ToString();
                //jawaban[j].transform.Find("Text").gameObject.SetActive(false);
            }
        }

        public void checkBenar()
        {
            string clicked = gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text;
            string answerss = voiceButton.GetComponentInChildren<Text>().text;
            Debug.Log(clicked);
            if (clicked == answerss)
            {
                Debug.Log("True");
                //benar.SetActive(true);
                //Invoke("setInactiveBenar", 1);
                KeaksaraanGameControl.score += 5;
            }
            else
            {
                //salah.SetActive(true);
                //Invoke("setInactiveSalah", 1);
                Debug.Log("False");
            }

            reload = true;
        }
    }
}