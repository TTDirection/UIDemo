using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance;
    public Button gongHuiBtn;
    public Button privateChatBtn;
    public Button copyBtn;

    public Button okBtn;

    public Toggle gonghui;
    public Toggle privateChat;
    public Toggle copy;

    public GameObject gonghuiGo;
    public GameObject privateChatGo;
    public GameObject copyGo;

    private GameObject messageBoxPanel;
    private List<GameObject> switchPanels=new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        RegisteEvent();
        InitData();
    }

    void RegisteEvent()
    {
        if(gongHuiBtn)
            gongHuiBtn.onClick.AddListener(OnGongHuiEvent);
        if(privateChatBtn)
            privateChatBtn.onClick.AddListener(OnPrivateChatEvent);
        if(copyBtn)
            copyBtn.onClick.AddListener(OnCopyTaskEvent);
        okBtn.onClick.AddListener(OnOKEvent);

        if (gonghui)
            gonghui.onValueChanged.AddListener((bool value) => OnGongHuiToggleEvent(value));
        if (privateChat)
            privateChat.onValueChanged.AddListener((bool value) => OnPrivateChatToggleEvent(value));
        if (copy)
            copy.onValueChanged.AddListener((bool value) => OnCopyToggleEvent(value));
    }

    void InitData()
    {
        messageBoxPanel = okBtn.transform.parent.gameObject;
        ShowMessageBoxState(false);

        switchPanels.Add(gonghuiGo);
        switchPanels.Add(privateChatGo);
        switchPanels.Add(copyGo);
        ShowWho(gonghuiGo, switchPanels);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    #region 按钮的注册事件
    private void OnGongHuiEvent()
    {
        Debug.Log("click gonghui button");
        ShowWho(gonghuiGo, switchPanels);
    }

    private void OnPrivateChatEvent()
    {
        Debug.Log("click privateChat button");
        ShowWho(privateChatGo, switchPanels);
    }

    private void OnCopyTaskEvent()
    {
        Debug.Log("click copyTask button");
        ShowWho(copyGo, switchPanels);
    }

    private void OnOKEvent()
    {
        Debug.Log("click ok button");
        ShowMessageBoxState(false);
       
    }

    private void OnToggleClick(Toggle toggle, bool value)
    {
    }

    private void OnGongHuiToggleEvent(bool isOn)
    {
        if(isOn)
        {
            ShowWho(gonghuiGo, switchPanels);
        }      
    }

    private void OnPrivateChatToggleEvent(bool isOn)
    {
        if (isOn)
        {
            ShowWho(privateChatGo, switchPanels);
        }
    }

    private void OnCopyToggleEvent(bool isOn)
    {
        if (isOn)
        {
            ShowWho(copyGo, switchPanels);
        }
    }
    #endregion

    #region 按钮的切换显示窗口
    public void ShowMessageBoxState(bool show)
    {
        if(!messageBoxPanel)
        {
            Debug.LogError("messageBoxPanel is null reference! please make sure that you have already assign value to the messageBoxPanel variable!");
            return;
        }
        messageBoxPanel.SetActive(show);
    }

    public void ShowGongHuiPanel(bool show)
    {
        if(!gonghuiGo)
        {
            Debug.LogError("gonghuiGo is null reference! please make sure that you have already assign value to the gonghuiGo variable!");
            return;
        }
        gonghuiGo.SetActive(show);
    }

    public void ShowPrivateChatPanel(bool show)
    {
        if (!privateChatGo)
        {
            Debug.LogError("privateChatGo is null reference! please make sure that you have already assign value to the privateChatGo variable!");
            return;
        }
        privateChatGo.SetActive(show);
    }

    public void ShowCopyPanel(bool show)
    {
        if (!copyGo)
        {
            Debug.LogError("copyGo is null reference! please make sure that you have already assign value to the copyGo variable!");
            return;
        }
        copyGo.SetActive(show);
    }

    /// <summary>
    /// 在一个容器里，显示哪个子对象
    /// </summary>
    /// <param name="showGo">容器中的子对象</param>
    /// <param name="gos">当前容器</param>
    public void ShowWho(GameObject showGo,List<GameObject> gos)
    {
        foreach(GameObject go in gos)
        {
            if(go == showGo)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }

    #endregion
}
