using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject creditsPanel;

    private const string firstLevel = "Level"; // muss durch tatsächlichen Namen ausgetauscht werden

    private bool creditsPanelOpen = false;

    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(firstLevel);
        });


        creditsButton.onClick.AddListener(() =>
        {
            creditsPanelOpen = !creditsPanelOpen;

            if (creditsPanelOpen)
            {
                creditsPanel.SetActive(true);
                creditsPanelOpen = true;
            }
            else
            {
                creditsPanel.SetActive(false);
                creditsPanelOpen = false;
            }
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void Start()
    {
        creditsPanel.SetActive(false);
    }
}
