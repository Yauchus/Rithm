using UnityEngine;

public class SongConductor : MonoBehaviour
{
    public static SongConductor Instance;

    public AudioSource music;
    public double songStartDspTime;
    public double songTime;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        songStartDspTime = AudioSettings.dspTime;
        if (music != null)
        {
            music.Play();
        }
    }

    void Update()
    {
        songTime = AudioSettings.dspTime - songStartDspTime;
    }

    public void StartSong()
    {
        songStartDspTime = AudioSettings.dspTime;
        if (music != null)
        {
            music.Play();
        }
    }
}