using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class PopulateMode2 : MonoBehaviour
{
    public Text statusText;
    public bool controller;
    public GameObject Content;
    public GameObject prefab;
    public int numberToCreate;

    public GameObject buttonNext, buttonPrev, btnSpeechAudio;
    
    public Sprite[] AnimalImages;
    public AudioClip[] audio, audioSpeech;
    
    public static List<Sprite> ListAnimalImages;
    public static List<AudioClip> ListAnimalAudio, ListAnimalSpeech;
    
    private static int position = 0;
    // Start is called before the first frame update
    void Start()
    {
        position = 0;
        statusText.text = position.ToString() + "/" + numberToCreate.ToString();
        if (controller != true)
        {
            populate();
            Content.GetComponent<Image>().sprite = ListAnimalImages[position];
            Content.GetComponent<AudioSource>().clip = ListAnimalAudio[position];
            btnSpeechAudio.GetComponent<AudioSource>().clip = ListAnimalSpeech[position];
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
        statusText.text = position.ToString() + "/" + (numberToCreate-1).ToString();
    }

    void populate(){
        GameObject newButton;
        ListAnimalImages = new List<Sprite>();
        ListAnimalAudio = new List<AudioClip>();
        ListAnimalSpeech = new List<AudioClip>();
        for (int i = 0; i < numberToCreate; i++)
        {
            newButton = Instantiate(prefab);
            newButton.GetComponent<Image>().sprite = AnimalImages[i];
            newButton.GetComponent<AudioSource>().clip = audio[i];
            ListAnimalImages.Add(AnimalImages[i]);
            ListAnimalAudio.Add(audio[i]);
            ListAnimalSpeech.Add(audioSpeech[i]);
        }
    }

    public void nextContent()
    {
        Content.GetComponent<Image>().sprite = ListAnimalImages[position+1];
        Content.GetComponent<AudioSource>().clip = ListAnimalAudio[position+1];
        btnSpeechAudio.GetComponent<AudioSource>().clip = ListAnimalSpeech[position + 1];
        position++;
    }
    
    public void previousContent()
    {
        Content.GetComponent<Image>().sprite = ListAnimalImages[position-1];
        Content.GetComponent<AudioSource>().clip = ListAnimalAudio[position-1];
        btnSpeechAudio.GetComponent<AudioSource>().clip = ListAnimalSpeech[position - 1];
        position--;
    }
}