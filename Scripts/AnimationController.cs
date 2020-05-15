using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnimationController : MonoBehaviour
    {
        public GameObject gameObject;
        private void Start()
        {
            lvl1DragDrop(gameObject);
        }

        void lvl1DragDrop(GameObject gameObject)
        {
            var delay = 2.0;
            Destroy(gameObject, 3);
        }
    }
}