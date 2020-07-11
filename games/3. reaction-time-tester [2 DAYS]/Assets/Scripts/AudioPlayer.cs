using UnityEngine;

// copied from Brackeys tutorial
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.5f, 1.5f)]
    public float pitch;

    private AudioSource src;

    public void SetSrc(AudioSource src)
    {
        this.src = src;
        src.clip = clip;
    }

    public void Play()
    {
        src.volume = volume;
        src.pitch = pitch;
        src.Play();
    }
}
public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;

    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogError("More than one AudioManager in the scene.");
        } else
        {
            instance = this;
        }
    }
    private void Start()
    {
        for(int i = 0; i<sounds.Length; i++)
        {
            GameObject go = new GameObject("Sound_" + i + "_" + sounds[i]);
            sounds[i].SetSrc(go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].Play();
                return;
            }
        }

        Debug.Log("No sound found");
    }
}
