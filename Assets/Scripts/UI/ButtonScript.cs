using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    Button myButton;

    [SerializeField] private string firstLevel = "Level";


    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnMyButtonClicked);
    }

    void OnMyButtonClicked()
    {
        SceneManager.LoadScene(firstLevel);
    }

}
