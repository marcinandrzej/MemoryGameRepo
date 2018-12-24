using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuiScriptGM : MonoBehaviour
{
    private int size;
    private GameManagerScriptGM gameManager;
    private SoundManagerScriptGM soundManager;
    private GameObject optionsPanel;
    private GameObject slider;

    private List<GameObject> gameButtons;
    private List<GameObject> menuButtons;

    public List<Sprite> spritesList;
    public Sprite blankSprite;
    public Sprite exitSprite;
    public Sprite reloadSprite;
    public Sprite optionsSprite;
    public Sprite optionsPanelSprite;
    public Sprite applySprite;
    public Sprite backgroundSprite;

    // Use this for initialization
    void Start ()
    {
        gameManager = transform.GetComponent<GameManagerScriptGM>();
        soundManager = transform.GetComponent<SoundManagerScriptGM>();
        soundManager.SetSoundLevel();
        gameButtons = new List<GameObject>();
        menuButtons = new List<GameObject>();
        size = gameManager.GetSize();
        SetUpBackground();
        SetUpButtons();
        SetUpOPtionsPanel();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void DeleteFromGui(GameObject button)
    {
        gameButtons.Remove(button);
        button.SetActive(false);
    }

    private void SetUpButtons()
    {
        GameObject button;

        //Game buttons
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                int index = x * size + y;
                button = new GameObject("Button" + index.ToString());
                button.transform.SetParent(transform);
                button.AddComponent<Button>();
                button.AddComponent<Image>();
                button.GetComponent<RectTransform>().localPosition = new Vector3(-300.0f + (x * 110.0f), 165.0f + (y * -110), 0.0f);
                button.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 100.0f);
                button.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                button.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                button.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                button.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
                button.GetComponent<Image>().sprite = blankSprite;
                GameObject but = button;
                int xx = x;
                int yy = y;
                gameButtons.Add(but);
                button.GetComponent<Button>().onClick.AddListener(delegate 
                {
                    gameManager.ButtonClicked(but, xx, yy);
                });
            }
        }

        //Menu buttons
        button = new GameObject("ReloadButton");
        button.transform.SetParent(transform);
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.GetComponent<RectTransform>().localPosition = new Vector3(-75.0f, 125.0f, 0.0f);
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 100.0f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(1.0f, 0.5f);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 0.5f);
        button.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        button.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        button.GetComponent<Image>().sprite = reloadSprite;
        button.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
        GameObject menuButton = button;
        menuButtons.Add(menuButton);

        button = new GameObject("OptionsButton");
        button.transform.SetParent(transform);
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.GetComponent<RectTransform>().localPosition = new Vector3(-75.0f, 0.0f, 0.0f);
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 100.0f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(1.0f, 0.5f);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 0.5f);
        button.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        button.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        button.GetComponent<Image>().sprite = optionsSprite;
        button.GetComponent<Button>().onClick.AddListener(delegate { ShowOptionsPanel(true); });
        GameObject optionsButton = button;
        menuButtons.Add(optionsButton);

        button = new GameObject("ExitButton");
        button.transform.SetParent(transform);
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.GetComponent<RectTransform>().localPosition = new Vector3(-75.0f, -125.0f, 0.0f);
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 100.0f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(1.0f, 0.5f);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 0.5f);
        button.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        button.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        button.GetComponent<Image>().sprite = exitSprite;
        button.GetComponent<Button>().onClick.AddListener(delegate { Application.Quit();/* SceneManager.LoadScene("MainMenuGM");*/ });
        GameObject exitButton = button;
        menuButtons.Add(exitButton);
    }

    public void Reveal(GameObject button, int index)
    {
        button.GetComponent<Image>().sprite = spritesList[index];
    }

    public void Hide(GameObject button)
    {
        button.GetComponent<Image>().sprite = blankSprite;
    }

    private void ShowOptionsPanel(bool show)
    {
        optionsPanel.SetActive(show);
        foreach (GameObject gO in gameButtons)
        {
            gO.SetActive(!show);
        }
        foreach (GameObject gO in menuButtons)
        {
            gO.SetActive(!show);
        }
    }

    private void SetUpOPtionsPanel()
    {
        optionsPanel = new GameObject("OptionsPanel");
        optionsPanel.AddComponent<Image>().sprite = optionsPanelSprite;
        optionsPanel.GetComponent<RectTransform>().SetParent(transform);
        optionsPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        optionsPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        optionsPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        optionsPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        optionsPanel.GetComponent<RectTransform>().sizeDelta = new Vector3(300.0f, 300.0f);
        optionsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 0.0f);
        optionsPanel.SetActive(false);

        //sound slider
        slider = DefaultControls.CreateSlider(new DefaultControls.Resources());
        slider.GetComponent<Slider>().minValue = 0.0f;
        slider.GetComponent<Slider>().maxValue = 1.0f;
        slider.GetComponent<Slider>().value = soundManager.GetSoundLevel();
        slider.GetComponent<RectTransform>().SetParent(optionsPanel.transform);
        slider.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        slider.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
        slider.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
        slider.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        slider.GetComponent<RectTransform>().sizeDelta = new Vector3(140.0f, 40.0f);
        slider.GetComponent<RectTransform>().anchoredPosition = new Vector3(50.0f, -60.0f, 0.0f);

        Image[] img = slider.GetComponentsInChildren<Image>();
        img[0].sprite = optionsPanelSprite;
        img[0].color = new Color32(150, 150, 150, 255);
        img[1].sprite = optionsPanelSprite;
        img[2].sprite = optionsPanelSprite;

        slider.GetComponent<Slider>().onValueChanged.AddListener(delegate {
            soundManager.UpdateSoundLevel(slider.GetComponent<Slider>().value);
        });

        //text near slider
        GameObject gO = new GameObject("SliderTxt");
        gO.AddComponent<Text>();
        gO.GetComponent<RectTransform>().SetParent(optionsPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(100.0f, 40.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-70.0f, -60.0f, 0.0f);
        gO.GetComponent<Text>().text = "Sound";
        gO.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        gO.GetComponent<Text>().fontStyle = FontStyle.BoldAndItalic;
        gO.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        gO.GetComponent<Text>().resizeTextForBestFit = true;
        gO.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        //apply buton
        gO = new GameObject("ApplyButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = applySprite;
        gO.GetComponent<RectTransform>().SetParent(optionsPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(100.0f, 100.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(55.0f, 100.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            PlayerPrefs.SetFloat("SoundLevelGM", soundManager.GetSoundLevel());
            ShowOptionsPanel(false);
        });

        //return button
        gO = new GameObject("BackButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = exitSprite;
        gO.GetComponent<RectTransform>().SetParent(optionsPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(100.0f, 100.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-55.0f, 100.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            soundManager.UpdateSoundLevel(PlayerPrefs.GetFloat("SoundLevelGM"));
            slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundLevelGM");
            ShowOptionsPanel(false);
        });
    }

    private void SetUpBackground()
    {
        GameObject bG = new GameObject("Background");
        bG.transform.SetParent(transform);
        bG.AddComponent<Image>();
        bG.GetComponent<Image>().sprite = backgroundSprite;
        bG.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 0.0f);
        bG.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 1.0f);
        bG.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        bG.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        bG.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 0.0f);
        bG.GetComponent<RectTransform>().offsetMax = new Vector2(0.0f, 0.0f);
    }

    public void End()
    {
        soundManager.PlaySound(Sounds.END_SOUND);

        GameObject endText = new GameObject("EndText");
        endText.AddComponent<Text>();
        endText.transform.SetParent(transform);
        endText.GetComponent<RectTransform>().SetParent(transform);
        endText.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        endText.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        endText.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        endText.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        endText.GetComponent<RectTransform>().sizeDelta = new Vector3(500.0f, 100.0f);
        endText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-100.0f, 0.0f);
        endText.GetComponent<Text>().text = "CONGRATULATIONS";
        endText.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        endText.GetComponent<Text>().fontStyle = FontStyle.BoldAndItalic;
        endText.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        endText.GetComponent<Text>().resizeTextForBestFit = true;
        endText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        Destroy(endText, 2.0f);
    }
}