using UnityEngine;
public class AudioClipsSource : MonoBehaviour
{

    [Header("Music Clips")]
    public AudioClip MainMenuClip;
    public AudioClip GamePlayClip;

    public AudioClip GenericButtonClick;
    public AudioClip PlayButtonClick;
    public AudioClip CloseButtonClip;

    public AudioClip LevelFailedClip;
    public AudioClip LevelSuccessClip;

    public AudioClip AchievementUnlockedClip;
    public AudioClip doorClip;


    public static AudioClipsSource Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
