using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject sidePanel;
    [SerializeField] private GameObject creditsPanel;

    public void StartARExperience()
    {
        SceneManager.LoadScene("ARPlaneTrackingScene");
    }

    public void ToggleSettings()
    {
       settingsPanel.SetActive(!settingsPanel.activeSelf);
        aboutPanel.SetActive(false); // Hide about panel when settings are open
        sidePanel.SetActive(!settingsPanel.activeSelf); // Hide side panel when settings are open
    }

    public void ToggleAbout()
    {
        aboutPanel.SetActive(!aboutPanel.activeSelf);
        sidePanel.SetActive(!aboutPanel.activeSelf); // Hide side panel when about is open
        settingsPanel.SetActive(false); // Hide settings panel when about is open

    }

public void ToggleSidePanel()
    {
        sidePanel.SetActive(!sidePanel.activeSelf);
    }

public void ShowCredits()
    {
        creditsPanel.SetActive(true);
        sidePanel.SetActive(false); // Hide side panel when credits are shown
        settingsPanel.SetActive(false); // Hide settings panel when credits are shown
        aboutPanel.SetActive(false); // Hide about panel when credits are shown
    }

    //Back to previous panel
    public void BackToMainMenu()
    {
        settingsPanel.SetActive(false);
        aboutPanel.SetActive(false);
        creditsPanel.SetActive(false);
        sidePanel.SetActive(true);
    }
}