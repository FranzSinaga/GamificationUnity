using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate;
    public Sprite[] AnimalImages;
    public AudioClip[] audio;

    private GameObject newButton;
    // Start is called before the first frame update
    void Start()
    {
        populate();
    }

    // Update is called once per frame
    void Update()    
    {
           
    }

    void populate(){
        for (int i = 0; i < 5; i++)
        {
            newButton = Instantiate(prefab);
            newButton.transform.SetParent(this.transform, false);
            //newButton.GetComponent<Image>().color = Random.ColorHSV();
            newButton.GetComponent<Image>().sprite = AnimalImages[i];
        }
    }
}