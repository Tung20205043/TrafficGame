
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button setting;
    [SerializeField] private Button xButton;
    [SerializeField] private Button helpButton;

    [SerializeField] private GameObject settingLabel;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helpLabel;
    [SerializeField] private GameObject helpUI;

    public Slider music;

    public AudioSource MusicSound;

    public static float musicValue;
    private void Awake()
    {
        startGame.onClick.AddListener(() => StartGameButton());
        setting.onClick.AddListener(() => SettingButton());
        xButton.onClick.AddListener(() => XButton());
        helpButton.onClick.AddListener(() => HelpButton());
        music.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        musicValue = music.value;

        MusicSound.volume = music.value;

    }
    void StartGameButton() {
        SceneManager.LoadScene(1);
    }
    void SettingButton() {
        settingLabel.SetActive(true);
        settingButton.SetActive(false);
    }
    void XButton() {
        settingLabel.SetActive(false);
        settingButton.SetActive(true);
    }
    void HelpButton() {
        helpLabel.SetActive(true);
    }
}
