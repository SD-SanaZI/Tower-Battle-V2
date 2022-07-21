using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonMeneger : MonoBehaviour
{
    private Button _pauseButton, _shildButton;
    private Label _time;
    public GameObject shild, PauseUI;
    public float time;

    void Start()
    {
        _time = GetComponent<UIDocument>().rootVisualElement.Q("Shild").Q<Label>("Time");
        _pauseButton = GetComponent<UIDocument>().rootVisualElement.Q("Pause").Q<Button>("PauseButton");
        _pauseButton.clickable.clicked += () =>
        {
            Debug.Log("Pause");
            Time.timeScale = (Time.timeScale + 1) % 2;
            PauseUI.GetComponent<PauseMeneger>().Activate();
        };
        _shildButton = GetComponent<UIDocument>().rootVisualElement.Q("Shild").Q<Button>("ShildButton");
        _shildButton.clickable.clicked += () =>
        {
            shild.GetComponent<ShildLogic>().ShildOn();
        };
    }

    // Update is called once per frame
    void Update()
    {
        time = shild.GetComponent<ShildLogic>().GetCoolDown();
        if(time >= 0)
           _time.text = ((int)time).ToString();
        else
            _time.text = "";
    }
}
