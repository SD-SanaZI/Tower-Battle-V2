using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HpBarMeneger : MonoBehaviour
{
    private VisualElement _hpBar;
    private Camera m_MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        _hpBar = GetComponent<UIDocument>().rootVisualElement.Q("Hp_Bar");
        Vector3 position = GetComponent<Transform>().position;
        position.x -= 1.5f;
        position.y += 2.5f;
        _hpBar.transform.position = RuntimePanelUtils.CameraTransformWorldToPanel(
    _hpBar.panel, position, m_MainCamera);
        if (position.x > 0)
            _hpBar.transform.scale = new Vector2(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHp(float hp)
    {
        _hpBar.Q<ProgressBar>("ProgressBar").lowValue = hp;
    }
}
