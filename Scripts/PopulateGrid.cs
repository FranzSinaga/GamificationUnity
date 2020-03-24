using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate;
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
        GameObject newObject;

        for (int i = 0; i < numberToCreate; i++)
        {
            newObject = (GameObject) Instantiate(prefab, transform);
            newObject.GetComponent<Image>().color = Random.ColorHSV();
        }
    }
}
