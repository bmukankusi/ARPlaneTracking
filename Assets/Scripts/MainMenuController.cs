using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject sidePanel;

    public void StartARExperience()
    {
        SceneManager.LoadScene("ARPlaneTrackingScene");
    }

    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void ToggleAbout()
    {
        aboutPanel.SetActive(!aboutPanel.activeSelf);
    }

    public void ToggleSidePanel()
    {
        sidePanel.SetActive(!sidePanel.activeSelf);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}