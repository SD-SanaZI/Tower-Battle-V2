using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMeneger : MonoBehaviour
{
    private Button _restartButton, _resumeButton;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        //        GetComponent<UIDocument>().enabled = true;
        gameObject.SetActive(true);
        _restartButton = GetComponent<UIDocument>().rootVisualElement.Q("Screen").Q<Button>("Restart");
        _resumeButton = GetComponent<UIDocument>().rootVisualElement.Q("Screen").Q<Button>("Resume");
        _restartButton.clickable.clicked += () =>
        {
            GetComponent<UIDocument>().rootVisualElement.Q("Screen").SetEnabled(false);
            Time.timeScale = (Time.timeScale + 1) % 2;
            SceneManager.LoadScene("Scenes/Game");
        };
        _resumeButton.clickable.clicked += () =>
        {
            Time.timeScale = (Time.timeScale + 1) % 2;
            //           GetComponent<UIDocument>().enabled = false;
            GetComponent<UIDocument>().rootVisualElement.Q("Screen").SetEnabled(false);
            gameObject.SetActive(false);
        };
    }
}
