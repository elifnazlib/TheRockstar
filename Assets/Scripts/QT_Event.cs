using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QT_Event : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] rings;
    [SerializeField] BoxCollider2D buttonWindow;
    [SerializeField] float speed = 2f;
    private bool isInputActive = true;
    private bool isGameOver = false;
    private float totalScore = 0;

    private float fillAmount = 1;
    private float timeThreshold = 0;
    private int randomNumber;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreTitle;
    [SerializeField] TextMeshProUGUI scoreInPanel;

    [SerializeField] GameObject[] stars;
    [SerializeField] ParticleSystem particleSystemForSuccess;
    float randomX, randomY;
    private float totalNotes = 144f;
    private int numOfCorrectClicks = 0;
    private float successRate = 0;
    [SerializeField] TextMeshProUGUI successRateText;

    [SerializeField] TextMeshProUGUI[] buttonScoreText;
    private string nthButtonScoreText = "first";

    void Start()
    {
        StartCoroutine(WaitBeforeDisappear());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            if (isInputActive == true)
            {
                if ((randomNumber == 0) && (Input.GetKeyDown("2") || Input.GetKeyDown("3") || Input.GetKeyDown("4")))
                {
                    if (nthButtonScoreText.Equals("first"))
                    {
                        nthButtonScoreText = "second";
                        StartCoroutine(FadeOutAndDestroy1(new Color(255, 0, 0, 255), "Missed!"));
                    }
                    else if (nthButtonScoreText.Equals("second"))
                    {
                        nthButtonScoreText = "first";
                        StartCoroutine(FadeOutAndDestroy2(new Color(255, 0, 0, 255), "Missed!"));
                    }

                    // StartCoroutine(FadeOutAndDestroy(new Color(255, 0, 0, 255), "Missed!"));
                    Debug.Log("first fail");
                    isInputActive = false;
                }
                else if ((randomNumber == 1) && (Input.GetKeyDown("1") || Input.GetKeyDown("3") || Input.GetKeyDown("4")))
                {
                    if (nthButtonScoreText.Equals("first"))
                    {
                        nthButtonScoreText = "second";
                        StartCoroutine(FadeOutAndDestroy1(new Color(255, 0, 0, 255), "Missed!"));
                    }
                    else if (nthButtonScoreText.Equals("second"))
                    {
                        nthButtonScoreText = "first";
                        StartCoroutine(FadeOutAndDestroy2(new Color(255, 0, 0, 255), "Missed!"));
                    }

                    // StartCoroutine(FadeOutAndDestroy(new Color(255, 0, 0, 255), "Missed!"));
                    Debug.Log("second fail");
                    isInputActive = false;
                }
                else if ((randomNumber == 2) && (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("4")))
                {
                    if (nthButtonScoreText.Equals("first"))
                    {
                        nthButtonScoreText = "second";
                        StartCoroutine(FadeOutAndDestroy1(new Color(255, 0, 0, 255), "Missed!"));
                    }
                    else if (nthButtonScoreText.Equals("second"))
                    {
                        nthButtonScoreText = "first";
                        StartCoroutine(FadeOutAndDestroy2(new Color(255, 0, 0, 255), "Missed!"));
                    }

                    // StartCoroutine(FadeOutAndDestroy(new Color(255, 0, 0, 255), "Missed!"));
                    Debug.Log("third fail");
                    isInputActive = false;
                }
                else if ((randomNumber == 3) && (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3")))
                {
                    if (nthButtonScoreText.Equals("first"))
                    {
                        nthButtonScoreText = "second";
                        StartCoroutine(FadeOutAndDestroy1(new Color(255, 0, 0, 255), "Missed!"));
                    }
                    else if (nthButtonScoreText.Equals("second"))
                    {
                        nthButtonScoreText = "first";
                        StartCoroutine(FadeOutAndDestroy2(new Color(255, 0, 0, 255), "Missed!"));
                    }

                    // StartCoroutine(FadeOutAndDestroy(new Color(255, 0, 0, 255), "Missed!"));
                    Debug.Log("fourth fail");
                    isInputActive = false;
                }
                else if (buttons[randomNumber].activeInHierarchy == true && ((randomNumber == 0 && Input.GetKeyDown("1")) || (randomNumber == 1 && Input.GetKeyDown("2")) || (randomNumber == 2 && Input.GetKeyDown("3")) || (randomNumber == 3 && Input.GetKeyDown("4"))))
                {
                    isInputActive = false;

                    // buttons[randomNumber].GetComponent<ParticleSystem>().Play();
                    particleSystemForSuccess.GetComponent<RectTransform>().anchoredPosition = new Vector2(randomX, randomY);
                    particleSystemForSuccess.Play();

                    totalScore += fillAmount * 100;
                    scoreText.text = ((int)totalScore).ToString();

                    numOfCorrectClicks++;
                    Debug.Log("Num of correct clicks: " + numOfCorrectClicks);

                    if (nthButtonScoreText.Equals("first"))
                    {
                        nthButtonScoreText = "second";
                        StartCoroutine(FadeOutAndDestroy1(new Color(0, 223, 9, 255), ((int)(fillAmount * 100)).ToString()));
                    }
                    else if (nthButtonScoreText.Equals("second"))
                    {
                        nthButtonScoreText = "first";
                        StartCoroutine(FadeOutAndDestroy2(new Color(0, 223, 9, 255), ((int)(fillAmount * 100)).ToString()));
                    }

                    // StartCoroutine(FadeOutAndDestroy(new Color(0, 223, 9, 255), ((int)(fillAmount * 100)).ToString()));
                    buttons[randomNumber].SetActive(false);

                    Debug.Log($"pressed {randomNumber + 1} successfully");
                }
            }

            timeThreshold += Time.deltaTime;

            if (timeThreshold > 0.05f)
            {
                timeThreshold = 0;
                fillAmount -= 0.06f;
            }

            if (fillAmount <= 0)
            {
                fillAmount = 0;
            }

            rings[randomNumber].GetComponent<Image>().fillAmount = fillAmount;
        }
    }

    void ActivateRandomly()
    {
        randomNumber = Random.Range(0, 4); // 0 - 1 - 2 - 3

        switch (randomNumber)
        {
            case 0:
                buttons[0].SetActive(true);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                buttons[3].SetActive(false);
                break;
            case 1:
                buttons[0].SetActive(false);
                buttons[1].SetActive(true);
                buttons[2].SetActive(false);
                buttons[3].SetActive(false);
                break;
            case 2:
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(true);
                buttons[3].SetActive(false);
                break;
            case 3:
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                buttons[3].SetActive(true);
                break;
        }

        RectTransform buttonWindowRect = buttonWindow.GetComponent<RectTransform>();
        RectTransform buttonRect = buttons[randomNumber].GetComponent<RectTransform>();

        randomX = Random.Range(buttonWindowRect.rect.min.x, buttonWindowRect.rect.max.x);
        randomY = Random.Range(buttonWindowRect.rect.min.y, buttonWindowRect.rect.max.y);

        buttonRect.anchoredPosition = new Vector2(randomX, randomY);

    }

    IEnumerator WaitBeforeDisappear()
    {
        for (int i = 0; i < 144; i++)
        {
            ActivateRandomly();
            isInputActive = true;
            Debug.Log("num is: " + randomNumber);
            // StartCoroutine(FadeOutAndDestroy(new Color(0, 223, 9, 255), ((int)(fillAmount * 100)).ToString()));
            yield return new WaitForSeconds(speed);
            fillAmount = 1;
        }
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        isInputActive = false;
        isGameOver = true;
        yield return new WaitForSeconds(1f);
        scoreText.enabled = false;
        scoreTitle.enabled = false;

        OpenGameOverPanel();
    }

    public void OpenGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        scoreInPanel.text = ((int)totalScore).ToString();

        successRate = 100 * numOfCorrectClicks / totalNotes;
        // string.Format("{0:F2}", successRate);    // shows only 2 digits after dot
        successRateText.text = string.Format("{0:0.00}", successRate).ToString() + " %";

        if (totalScore >= 1000 && totalScore < 3000)
        {
            stars[0].SetActive(true);
        }
        else if (totalScore >= 3000 && totalScore < 5000)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if (totalScore >= 5000)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }

        Debug.Log($"total score is: {(int)totalScore}");
    }

    // IEnumerator FadeOutAndDestroy(Color buttonColor, string buttonText)     // Missed: FF6363 Success: 00DF09
    // {
    //     buttonScoreText.GetComponent<RectTransform>().anchoredPosition = new Vector2(randomX + 133, randomY);
    //     buttonScoreText.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 255);
    //     buttonScoreText.text = buttonText;
    //     buttonScoreText.gameObject.SetActive(true);

    //     float startAlpha = 1;
    //     float time = 0;

    //     while (time < 2)
    //     {
    //         time += Time.deltaTime;
    //         float alpha = Mathf.Lerp(startAlpha, 0, time / 2);
    //         buttonScoreText.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);
    //         yield return null;
    //     }
    // }

    IEnumerator FadeOutAndDestroy1(Color buttonColor, string buttonText)     // Missed: FF6363 Success: 00DF09
    {
        buttonScoreText[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(randomX + 200, randomY);
        buttonScoreText[0].color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 255);
        buttonScoreText[0].text = buttonText;
        buttonScoreText[0].gameObject.SetActive(true);

        float startAlpha = 1;
        float time = 0;

        while (time < 2)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0, time / 2);
            buttonScoreText[0].color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);
            yield return null;
        }
    }

    IEnumerator FadeOutAndDestroy2(Color buttonColor, string buttonText)     // Missed: FF6363 Success: 00DF09
    {
        buttonScoreText[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(randomX + 200, randomY);
        buttonScoreText[1].color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 255);
        buttonScoreText[1].text = buttonText;
        buttonScoreText[1].gameObject.SetActive(true);

        float startAlpha = 1;
        float time = 0;

        while (time < 2)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0, time / 2);
            buttonScoreText[1].color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);
            yield return null;
        }
    }
}
