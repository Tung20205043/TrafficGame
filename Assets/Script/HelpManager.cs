
using UnityEngine;

using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    public GameObject[] Rules;
    public static int currentRlIndex = 0;
    [SerializeField] private Button xButton;
    [SerializeField] private GameObject helpLabel;
    private void Awake() {
        xButton.onClick.AddListener(() => XButton());
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            MoveBackGround(1);

        }
     
       
    }

    void MoveBackGround(int offset) {
        if (currentRlIndex + offset > Rules.Length - 1) {
            Rules[currentRlIndex].SetActive(false);
            currentRlIndex = 0;
            Rules[0].SetActive(true);
            return;
        }
        int newIndex = Mathf.Clamp(currentRlIndex + offset, 0, Rules.Length - 1);
        Rules[currentRlIndex].SetActive(false);
        currentRlIndex = newIndex;
        Rules[newIndex].SetActive(true);
    }
    void XButton() {
        helpLabel.SetActive(false);
    }
}
