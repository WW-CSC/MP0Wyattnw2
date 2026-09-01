using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public Button m_QuitButton, m_SubCredits, m_resetScore, m_volumeMenu, m_tradeButton, m_tradeAll;
    public Button[] closeButtons;
    public TextMeshProUGUI[] buttonsPressed;
    public TextMeshProUGUI m_tradeScore;
    private int buttonClickCount = 0, tradeCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in closeButtons)
        {
            item.onClick.AddListener(IncrementCurrentCount);
        }
        m_QuitButton.onClick.AddListener(QuitButton);
        m_SubCredits.onClick.AddListener(IncrementCurrentCount);
        m_resetScore.onClick.AddListener(ResetScore);
        m_volumeMenu.onClick.AddListener(IncrementCurrentCount);
        m_resetScore.gameObject.SetActive(false);
        foreach (var item in buttonsPressed)
        {
            item.gameObject.SetActive(false); 
        }
        m_tradeScore.gameObject.SetActive(false);
        m_tradeAll.gameObject.SetActive(false);
        m_tradeButton.onClick.AddListener(Trade1);
        m_tradeAll.onClick.AddListener(TradeAll);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonClickCount != 0)
        {
            m_resetScore.gameObject.SetActive(true);
            foreach (var item in buttonsPressed)
            {
                item.gameObject.SetActive(true);
            }
        }
        SetTradeAllButton();
        UpdateTradeScore();
    }

    void ResetScore()
    {
        buttonClickCount = 0;
        m_resetScore.gameObject.SetActive(false);
        foreach (var item in buttonsPressed)
        {
            item.gameObject.SetActive(false);
        }
    }


    void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
    }

    void IncrementCurrentCount()
    {
        buttonClickCount++;
        foreach (var item in buttonsPressed)
        {
            item.SetText($"Score: {buttonClickCount}");
        }
    }

    void Trade1()
    {
        if( buttonClickCount >= 10)
        {
            SetTradeScore(1);
            buttonClickCount -= 10;
            foreach (var item in buttonsPressed)
            {
                item.SetText($"Score: {buttonClickCount}");
            }
            SetTradeAllButton();
        }
        else
        {
            foreach (var item in buttonsPressed)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    void TradeAll()
    {
        int toAdd = buttonClickCount / 10;
        int left = buttonClickCount % 10;
        SetTradeScore(toAdd);
        buttonClickCount = left;
        if (buttonClickCount == 0)
        {
            foreach (var item in buttonsPressed)
            {
                item.gameObject.SetActive(false);
            }
            SetTradeAllButton();
        }
        else
        {
            foreach (var item in buttonsPressed)
            {
                item.SetText($"Score: {buttonClickCount}");
            }
        }
    }
    void SetTradeAllButton()
    {
        if(buttonClickCount >= 10)
        {
            m_tradeAll.gameObject.SetActive(true);
        }
        else
        {
            m_tradeAll.gameObject.SetActive(false);
        }
    }
    void SetTradeScore(int toAdd)
    {
        tradeCount += toAdd;
    }
    void UpdateTradeScore()
    {
        if(tradeCount > 0)
        {
            m_tradeScore.gameObject.SetActive(true);
            m_tradeScore.SetText($"Super Points: {tradeCount}");
        }
    }
}
