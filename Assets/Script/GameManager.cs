
using UnityEngine;


[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour {
    public static bool continueGame = false;
    public static float score = 0;
    public static float difficultly = 0;

    public static bool canMove = false;
    public static float music = 0;
    public static float soundEffect = 0;
    public GameObject pauseButton;

    public static GameManager Instance;

    public static event System.Action<bool> OnPauseButtonStateChanged;

    
    private void Awake() {
        score = 0;
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        
    }
    public void SetPauseButtonActive(bool isActive) {
        pauseButton.SetActive(isActive);
    }

}
