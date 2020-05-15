using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
