using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Signal : MonoBehaviour {
    protected float time;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private Sprite[] signal;
    [SerializeField] private GameObject signalObj;
    protected float greenTime = 40;
    protected float redTime = 20;
    protected float yellowTime = 2;
    private int phaseCount = 0;
    private Image signalImage;
    private bool debug = true;

    void Start() {
        time = redTime;
        UpdateTimerText();
        signalImage = signalObj.GetComponentInChildren<Image>();
        signalImage.sprite = signal[2];
        GameManager.canMove = false;
        StartCoroutine(CountdownTimer());

    }
    private void Update() {
        
    }
    void UpdateTimerText() {
        
        TimerText.text = Mathf.RoundToInt(time).ToString();
    }

    IEnumerator CountdownTimer() {
        while (debug) {
            while (!GameManager.continueGame) {
                yield return null; 
            }
            yield return new WaitForSeconds(1f);
            time -= 1;
            UpdateTimerText();
            if (time <= 0) {
                SwitchPhase();
            }
        }
    }

    void SwitchPhase() {
        phaseCount = (phaseCount + 1) % 3;

        switch (phaseCount) {
            case 0:
                time = redTime;
                signalImage.sprite = signal[2];
                GameManager.canMove = false;
                break;
            case 1:
                time = yellowTime;
                signalImage.sprite = signal[1];
                GameManager.canMove = true;
                break;
            case 2:
                time = greenTime;
                signalImage.sprite = signal[0];
                GameManager.canMove = true;
                break;
        }

        UpdateTimerText();
    }
}
