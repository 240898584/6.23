using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : ViewBase
{
    Button Button1;
    public override void Init(UIWindow uiBase)
    {
        base.Init(uiBase);
        Button1 = uiBase.transform.Find("Button").GetComponent<Button>();
        Button1.onClick.AddListener(OnButton1Click);
    }

    private void OnButton1Click()
    {
        GameScenesManager.Instance.LoadSceneAsync("Game", "CSVPanel");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
