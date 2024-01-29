
using UnityEngine;

public class SoundEffController : MonoBehaviour {
    [SerializeField] private AudioSource m_Source;
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioClip plusScore;
    [SerializeField] private AudioClip minusScore;
    public static bool rightChoice;
    public static bool playSound;
    void Start() {
        playSound = false;
        m_Source.clip = plusScore;
        MusicSource.volume = StartGame.musicValue;
    }


    void Update() {
        if (!GameManager.continueGame) {
            MusicSource.Stop();
        } 
        if (!MusicSource.isPlaying && GameManager.continueGame) {
                MusicSource.Play();
        }

        if (rightChoice && playSound) {
            m_Source.clip = plusScore;
            m_Source.Play();
            playSound = false;
        }
        if (!rightChoice && playSound) {
            {
                m_Source.clip = minusScore;
                m_Source.Play();
                playSound = false;
            }
        }
    }
}
