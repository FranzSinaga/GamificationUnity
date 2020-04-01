using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject winText;
    public int objectCount;
    public Vector2[] fixPosition;
    public static List<Vector2> listPosition;
    public static List<int> randomList;
    public static bool updated = false;
    void Start()
    {
        winText.SetActive(false);
        createListPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Darat.locked && Air.locked && Udara.locked)
        {
            updated = true;
            Air.restart = true;
            Darat.restart = true;
            Udara.restart = true;
            createListPosition();
        }
    }

    void createListPosition()
    {
        listPosition = new List<Vector2>();
        randomList = new List<int>();
        for (int i = 0; i < objectCount; i++)
        {
            listPosition.Add(fixPosition[i]);
            randomList.Add(i);
        }
    }
}
