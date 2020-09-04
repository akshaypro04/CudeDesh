using UnityEngine;


    [System.Serializable]
    public class Sound
    {
        public string Name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(0.1f, 3f)]
        public float pitch;

        public bool Loop;

        [HideInInspector]
        public AudioSource audioSource;
    }


    [System.Serializable]
    public class Music
    {
        public string Name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(0.1f, 3f)]
        public float pitch;

        public bool Loop;

        [HideInInspector]
        public AudioSource audioSource;
    }
