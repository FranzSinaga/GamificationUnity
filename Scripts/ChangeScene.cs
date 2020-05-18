using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMenu(string sceneName){
        Application.LoadLevel(sceneName);
    }
    
    public void exitGame(){
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void voice(Button btn)
    {
        if (btn.interactable)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
