using UnityEngine;
using UnityEngine.UI;

public class UImode : MonoBehaviour {
    public int modeIndex;
    public Toggle mytoggle;
    public Image img;
    public static int modeValue = 0;

    void Start() {
        mytoggle.onValueChanged.AddListener(OnValueChange);
        modeValue = PlayerPrefs.GetInt("Playmode", 0);
        img.color = modeValue == modeIndex ? Color.red : Color.white;
        mytoggle.isOn = modeIndex == modeValue;
    }

    void OnValueChange(bool isOn) {
        img.color = isOn ? Color.red : Color.white;
        
        PlayerPrefs.SetInt("Playmode", modeIndex);
        modeValue = modeIndex;
        PlayerPrefs.Save();
    }

    
}
