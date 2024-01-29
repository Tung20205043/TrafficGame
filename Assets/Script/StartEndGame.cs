using System.Collections;

using TMPro;
using UnityEngine;

public class StartEndGame : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI readyText;
    [SerializeField] private AudioSource MyPlayer;
    [SerializeField] private AudioClip StartAudio;

    public GameObject ready;
    void Start() {
        readyText.text = "Ready";
        StartCoroutine(RoundSet());
    }
    IEnumerator RoundSet() {
        yield return new WaitForSeconds(1f);
        readyText.text = "3";
        MyPlayer.Play();
        yield return new WaitForSeconds(1f);
        readyText.text = "2";
        MyPlayer.Play();
        yield return new WaitForSeconds(1f);
        readyText.text = "1";
        MyPlayer.Play();
        yield return new WaitForSeconds(1f);
        readyText.text = "Start";
        MyPlayer.clip = StartAudio;
        MyPlayer.Play();
        ready.SetActive(false);
        GameManager.continueGame = true;
    }
}
