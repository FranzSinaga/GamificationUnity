using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BGSoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    private static BGSoundScript instance = null;
    private bool isPause = false;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
        String activeScene = SceneManager.GetActiveScene().name;
        if (activeScene.Contains("Lvl"))
        {
            this.gameObject.GetComponent<AudioSource>().Pause();
            isPause = true;
        }
        else
        {
            if (isPause)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
                isPause = false;
            }
            else
            {
                Debug.Log(isPause);
            }
        }
    }
}
