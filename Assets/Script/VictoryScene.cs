using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScene : MonoBehaviour
{
    [SerializeField] private Button home;
    void Start()
    {
        home.onClick.AddListener(() => HomeBack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void HomeBack() {
        SceneManager.LoadScene(0);
    }
}
