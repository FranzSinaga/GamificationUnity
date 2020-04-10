using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darat : MonoBehaviour
{
    [SerializeField] private Transform bearPlace;

    private Vector2 initialPosition, posisiAwal;

    private float deltaX, deltaY;
    private int tempPositionIndex;
    private Vector2 vectorTemp;
    public static bool locked, restart;
    
    //Object Image
    public Sprite[] spriteImage;
    
    void Start()
    {
        //GameControl.score = 0;
        GameControl.updated = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteImage[0];
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
                    if (Mathf.Abs(transform.position.x - bearPlace.position.x) <= 0.5f && 
                        Mathf.Abs(transform.position.y - bearPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(bearPlace.position.x, bearPlace.position.y);
                        transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        locked = true;
                        getTempPosition();
                        GameControl.score += 5;
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
        getRandomImage();
        transform.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    void getRandomImage()
    {
        int index = Random.Range(0, spriteImage.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteImage[index];
    }
}
