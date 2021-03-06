﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatScript : MonoBehaviour {
    public Button sendMsgBtn;

    public Text chatText;
    public InputField chatInput;
    public RectTransform content;
    public ScrollRect scrollrect;
    // Use this for initialization
    void Start () {
        sendMsgBtn.onClick.AddListener(OnSendMsgEvent);
    }
	
	// Update is called once per frame
	void Update () {
        //content.sizeDelta= new Vector2( chatText.rectTransform.rect.width, chatText.rectTransform.rect.height);
	}

    private void OnSendMsgEvent()
    {
        if(string.IsNullOrEmpty(chatInput.text))
        {
            UIManager.Instance.ShowMessageBoxState(true);
            return;
        }
        string sendMsg = "\n " + "<color=blue>" + GameMode.userName + "</color>:" + chatInput.text;
        chatText.text += sendMsg;
        chatInput.text = "";
        //为了超出显示区域后，能在最下面显示出来
        Canvas.ForceUpdateCanvases();
        if(scrollrect)
            scrollrect.verticalNormalizedPosition = 0;
        Canvas.ForceUpdateCanvases();
    }
}
