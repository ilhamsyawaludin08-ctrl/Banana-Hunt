using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    public static VolumeController instance;

    public Slider volumeSlider;
    public AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume", 0f);

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        audioSource.volume = savedVolume;

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        SetupSlider();
    }

    // 🔥 INI YANG BIKIN SLIDER SELALU KEDETECT
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        volumeSlider = null; // reset biar cari ulang
        SetupSlider();
    }

    void SetupSlider()
    {
        volumeSlider = FindObjectOfType<Slider>();

        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;

            volumeSlider.onValueChanged.RemoveAllListeners();
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("volume", value);
    }
}