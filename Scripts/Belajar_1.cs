using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class Belajar_1 : MonoBehaviour
{
        public bool controller;
        public GameObject Content;
        public GameObject prefab;
        public int numberToCreate = 5;

        public GameObject buttonNext, buttonPrev;

        public Sprite[] AksaraImages;
        public AudioClip[] audio;

        public static List<Sprite> ListAksaraImages;
        public static List<AudioClip> ListAksaraAudio;

        private static int position = 0;
        // Start is called before the first frame update
        void Start()
        {
            if (controller != true)
            {
                populate();
                Content.GetComponent<Image>().sprite = ListAksaraImages[position];
                Content.GetComponent<AudioSource>().clip = ListAksaraAudio[position];
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (position == numberToCreate-1)
            {
                buttonNext.SetActive(false);
                buttonPrev.SetActive(true);
            }
            else if(position == 0)
            {
                buttonNext.SetActive(true);
                buttonPrev.SetActive(false);
            }
            else
            {
                buttonNext.SetActive(true);
                buttonPrev.SetActive(true);
            }
        }

        void populate(){
            GameObject newButton;
            ListAksaraImages = new List<Sprite>();
            ListAksaraAudio = new List<AudioClip>();
            for (int i = 0; i < numberToCreate; i++)
            {
                newButton = Instantiate(prefab);
                newButton.GetComponent<Image>().sprite = AksaraImages[i];
                newButton.GetComponent<AudioSource>().clip = audio[i];
                ListAksaraImages.Add(AksaraImages[i]);
                ListAksaraAudio.Add(audio[i]);
            }
        }

        public void nextContent()
        {
            Content.GetComponent<Image>().sprite = ListAksaraImages[position+1];
            Content.GetComponent<AudioSource>().clip = ListAksaraAudio[position+1];
            position++;
        }

        public void previousContent()
        {
            Content.GetComponent<Image>().sprite = ListAksaraImages[position-1];
            Content.GetComponent<AudioSource>().clip = ListAksaraAudio[position-1];
            position--;
        }
}
