
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Button[] restart;
    [SerializeField] AudioSource click;
    [SerializeField] private Button pause;
    [SerializeField] private Button contin;
    [SerializeField] private Button home;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    private void Awake() {
        for (int i = 0; i < restart.Length; i++) {
            restart[i].onClick.AddListener(() => ResetGame());
        }
        pause.onClick.AddListener(() => PauseGame());
        contin.onClick.AddListener(() => ContinueGame());
        home.onClick.AddListener(() => HomeBack());
    }
    void ResetGame() {
        click.Play();
        SceneManager.LoadScene(1);
    }
    void PauseGame() {
        click.Play();
        pausePanel.SetActive(true);
        GameManager.continueGame = false;
        //pauseButton.SetActive(false);
        GameManager.Instance.SetPauseButtonActive(false);

    }
    void ContinueGame() {
        click.Play();
        pausePanel.SetActive(false);
        GameManager.continueGame = true;
        //pauseButton.SetActive(true);
        GameManager.Instance.SetPauseButtonActive(true);
    }
    void HomeBack() { 
        SceneManager.LoadScene(0);
    }
}
