using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Button _restartButton;
    private Label _message;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Activate(string message)
    {
        gameObject.SetActive(true);
        Time.timeScale = (Time.timeScale + 1) % 2;
        _message = GetComponent<UIDocument>().rootVisualElement.Q("Screen").Q<Label>("Text");
        _message.text = message;
        _restartButton = GetComponent<UIDocument>().rootVisualElement.Q("Screen").Q<Button>("NewGame");
        _restartButton.clickable.clicked += () =>
        {
            GetComponent<UIDocument>().rootVisualElement.Q("Screen").SetEnabled(false);
            Time.timeScale = (Time.timeScale + 1) % 2;
            SceneManager.LoadScene("Scenes/Game");
        };
    }
}
