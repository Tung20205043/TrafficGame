using System.Collections;
using TMPro;
using UnityEngine;
using static GameManager;
public class MotorBike : CarController
{
    [SerializeField] protected GameObject transport;
    [SerializeField] protected GameObject VictoryPanel;
    protected float moveSpeed;
    public GameObject Transport => transport;
    public GameObject[] NotiUI;
    private float zRangeMin = 4.2f;
    private float zRangeMax = 15.5f;
    public static Transform playerPosition;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scorePlus;
    [SerializeField] private AudioSource trafficAccident;
    void Start()
    {
        
        switch (UImode.modeValue) {
            case 0:
                moveSpeed = 7;
                break;
            case 1:
                moveSpeed = 12;
                break;
            case 2:
                moveSpeed = 15;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transport.transform;
        Move();
        scoreText.text = "" + score;
    }
    public override void Move() {
        if ( !continueGame)
        {
            return;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
                transport.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                transport.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                transport.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transport.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }

            float zPosition = transport.transform.position.z;
            zPosition = Mathf.Clamp(zPosition, zRangeMin, zRangeMax);
            transport.transform.position = new Vector3(transport.transform.position.x, transport.transform.position.y, zPosition);
    }
    private void OnTriggerEnter(Collider other) {
        if (!continueGame) { return; }
        if (other.CompareTag("Traffic")) {
            if (!canMove) {
                SoundEffController.playSound = true;
                SoundEffController.rightChoice = false;
                NotiUI[3].gameObject.SetActive(true);
                GameManager.Instance.SetPauseButtonActive(false);
                continueGame = false;
            } else {
                StartCoroutine(PlusScore());
                SoundEffController.playSound = true;
                SoundEffController.rightChoice = true;          
                score += 10; 
            };
        }
        if (other.CompareTag("CaB")) {
            StartCoroutine(PlusScore());
            SoundEffController.playSound = true;
            SoundEffController.rightChoice = true;
            score += 10;
        }
        if (other.CompareTag("CarOnly")) {
            SoundEffController.playSound = true;
            SoundEffController.rightChoice = false;
            NotiUI[1].gameObject.SetActive(true);
            Instance.SetPauseButtonActive(false);
            continueGame = false;

        }
        if (other.CompareTag("RightWay")) {
            StartCoroutine(PlusScore());
            SoundEffController.playSound = true;
            SoundEffController.rightChoice = true;
            score += 10;
        }
        if (other.CompareTag("WrongWay")) {
            SoundEffController.playSound = true;
            SoundEffController.rightChoice = false;
            NotiUI[2].gameObject.SetActive(true);
            GameManager.Instance.SetPauseButtonActive(false);
            continueGame = false;
        }
        if (other.CompareTag("RandomCar")) {
            SoundEffController.playSound = true;
            SoundEffController.rightChoice = false;
            trafficAccident.Play();
            this.gameObject.SetActive(false);
            NotiUI[0].gameObject.SetActive(true);
            GameManager.Instance.SetPauseButtonActive(false);
            continueGame = false;
        }
        if (other.CompareTag("Goal")) {
            SoundEffController.playSound = true;
            SoundEffController.rightChoice = true;
            GameManager.continueGame = false;
            VictoryPanel.SetActive(true);
        }

        IEnumerator PlusScore() {
            scorePlus.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            scorePlus.SetActive(false);
        }
    }
}
