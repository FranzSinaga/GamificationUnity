using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class PopulateMode2 : MonoBehaviour
{
    public bool controller;
    public GameObject Content;
    public GameObject prefab;
    public int numberToCreate;
    private static int position = 0;
    public Sprite[] AnimalImages;
    public AudioClip[] audio;
    public static List<Sprite> ListAnimalImages;
    public static List<AudioClip> ListAnimalAudio;
    private GameObject newButton;
    // Start is called before the first frame update
    void Start()
    {
        if (controller != true)
        {
            populate();
            Content.GetComponent<Image>().sprite = ListAnimalImages[position];
            Content.GetComponent<AudioSource>().clip = ListAnimalAudio[position];
        }
    }

    // Update is called once per frame
    void Update()    
    {
           
    }

    void populate(){
        ListAnimalImages = new List<Sprite>();
        ListAnimalAudio = new List<AudioClip>();
        for (int i = 0; i < 5; i++)
        {
            newButton = Instantiate(prefab);
            //newButton.transform.SetParent(this.transform, false);
            //newButton.GetComponent<Image>().color = Random.ColorHSV();
            newButton.GetComponent<Image>().sprite = AnimalImages[i];
            newButton.GetComponent<AudioSource>().clip = audio[i];
            ListAnimalImages.Add(AnimalImages[i]);
            ListAnimalAudio.Add(audio[i]);
        }
    }

    public void nextContent()
    {
        Content.GetComponent<Image>().sprite = ListAnimalImages[position+1];
        Content.GetComponent<AudioSource>().clip = ListAnimalAudio[position+1];
        position++;
    }
    
    public void previousContent()
    {
        Content.GetComponent<Image>().sprite = ListAnimalImages[position-1];
        Content.GetComponent<AudioSource>().clip = ListAnimalAudio[position-1];
        position--;
    }
}