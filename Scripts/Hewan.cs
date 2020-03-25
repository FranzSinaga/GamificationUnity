using UnityEngine;

namespace DefaultNamespace
{
    public class Hewan
    {
        public Sprite Icon;
        public AudioSource Audio;
        public Hewan(Sprite icon, AudioSource audio)
        {
            Icon = icon;
            Audio = audio;
        }
    }
}