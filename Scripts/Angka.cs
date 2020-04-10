using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Angka : MonoBehaviour
{
    public GameObject question;
    public Sprite[] imageObj;
    private int jumlahGambar;
    public GameObject[] GameObjects;
    private static int answer;
    private int[] choice;
    private bool reload = false;
    public bool controller;

    public int jumlahJawaban;
    // Start is called before the first frame update
    void Start()
    {
        if (!controller)
        {
            reload =false;
            int index = Random.Range(1,8);
            jumlahGambar = index;
            answer = index;
            fillContent(index);
            fillAnswerList(answer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reload)
        {
            setInactiveObj();
            int index = Random.Range(1,8);
            jumlahGambar = index;
            answer = index;
            fillContent(index);
            fillAnswerList(answer);
            reload =false;
        }
    }

    void fillAnswerList(int rightAnswer)
    {
        int i = 0;
        int random;
        List<int> choiceText = new List<int>();
        while (i < jumlahJawaban)
        {
            random = Random.Range(1, 8);
            
            if (!choiceText.Contains(rightAnswer))
            {
                random = rightAnswer;
                choiceText.Add(random);
                i++;
                continue;
            } else if (!choiceText.Contains(random))
            {
                choiceText.Add(random);
                i++;
                continue;
            }
        }

        Shuffle(choiceText);
        for (int j = 0; j < choiceText.Count; j++)
        {
            Debug.Log(choiceText[j]);
            GameObjects[j].transform.Find("Text").gameObject.GetComponent<Text>().text = choiceText[j].ToString();
        }
    }

    void Shuffle(List<int> alpha)
    {
        for (int i = 0; i < alpha.Count; i++) {
            int temp = alpha[i];
            int randomIndex = Random.Range(i, alpha.Count);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
    }
    
    void fillContent(int jumlah)
    {
        for (int i = 1; i <= jumlah; i++)
        {
            String obj = "Image" + i;
            question.transform.Find(obj).gameObject.SetActive(true);
        }
    }

    void setInactiveObj()
    {
        for (int i = 1; i <= 8; i++)
        {
            String obj = "Image" + i;
            question.transform.Find(obj).gameObject.SetActive(false);
        }
    }

    public void checkBenar()
    {
        int clicked = int.Parse(gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        Debug.Log(answer);
        if (clicked == answer)
        {
            Debug.Log("True");
            KeaksaraanGameControl.score += 5;
        }
        else
        {
            Debug.Log("False");
        }

        reload = true;
    }
}
