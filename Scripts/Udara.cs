using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Udara : MonoBehaviour
{
    [SerializeField] private Transform koalaPlace;

    private Vector2 initialPosition, posisiAwal;
    private float deltaX, deltaY;
    private int tempPositionIndex;
    private Vector2 vectorTemp;
    public static bool locked, restart;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dragAndDrop();
        if (restart)
        {
            reload();
            dragAndDrop();
            restart = false;
        }
    }

    void getTempPosition()
    {
        int index = Random.Range(0, GameControl.randomList.Count);
        vectorTemp = GameControl.listPosition[GameControl.randomList[index]];
        GameControl.randomList.RemoveAt(index);
    }
    
    void dragAndDrop()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - koalaPlace.position.x) <= 0.5f && 
                        Mathf.Abs(transform.position.y - koalaPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(koalaPlace.position.x, koalaPlace.position.y);
                        locked = true;
                        getTempPosition();
                    }
                    else
                    {
                        if (!GameControl.updated)
                        {
                            transform.position = new Vector2(initialPosition.x, initialPosition.y);
                        }
                        else
                        {
                            transform.position = vectorTemp;
                        }
                    }
                    break;
            }
        }
    }

    void reload()
    {
        //transform.position = new Vector2(initialPosition.x, initialPosition.y);
        transform.position = vectorTemp;
        locked = false;
    }
}
