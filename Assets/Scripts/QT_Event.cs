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
                    Debug.Log("first fail");
                    isInputActive = false;
                }
                else if ((randomNumber == 1) && (Input.GetKeyDown("1") || Input.GetKeyDown("3") || Input.GetKeyDown("4")))
                {
                    Debug.Log("second fail");
                    isInputActive = false;
                }
                else if ((randomNumber == 2) && (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("4")))
                {
                    Debug.Log("third fail");
                    isInputActive = false;
                }
                else if ((randomNumber == 3) && (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3")))
                {
                    Debug.Log("fourth fail");
                    isInputActive = false;
                }
                else if (buttons[randomNumber].activeInHierarchy == true && ((randomNumber == 0 && Input.GetKeyDown("1")) || (randomNumber == 1 && Input.GetKeyDown("2")) || (randomNumber == 2 && Input.GetKeyDown("3")) || (randomNumber == 3 && Input.GetKeyDown("4"))))
                {
                    totalScore += fillAmount * 100;
                    scoreText.text = ((int)totalScore).ToString();

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

        float randomX = Random.Range(buttonWindowRect.rect.min.x, buttonWindowRect.rect.max.x);
        float randomY = Random.Range(buttonWindowRect.rect.min.y, buttonWindowRect.rect.max.y);

        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
    }

    IEnumerator WaitBeforeDisappear()
    {
        for (int i = 0; i < 144; i++)
        {
            ActivateRandomly();
            isInputActive = true;
            Debug.Log("num is: " + randomNumber);
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
        gameOverPanel.SetActive(true);
        scoreInPanel.text = ((int)totalScore).ToString();

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
}
