using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class AnimationController : MonoBehaviour
    {
        //public GameObject gameObject;
        private void Start()
        {
            String activeScene = SceneManager.GetActiveScene().name;
            if (activeScene.Contains("Buah"))
            {
                Debug.Log("BUAH");
                Destroy(this.gameObject, 3);
            }else
            {
                lvl1DragDrop(this.gameObject);    
            }
        }

        void lvl1DragDrop(GameObject gameObject)
        {
            var delay = 2.0;
            Destroy(gameObject, 3);
        }
    }
}