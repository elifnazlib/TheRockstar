using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] GameObject storyPanel;
    public void OpenStoryPanel()
    {
        storyPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Main Game");
    }
}
