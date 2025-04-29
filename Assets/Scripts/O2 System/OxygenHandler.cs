using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OxygenHandler : MonoBehaviour
{
    [Header("Oxygen Settings")]
    public float maxOxygen = 100f;
    public float currentOxygen;
    [SerializeField] private float decreaseAmount = 5f;
    [SerializeField] private float decreaseInterval = 2f;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI oxygenText;
    [SerializeField] private Image oxygenTankIcon;

    SkillCheckScript skillCheck;
    AudioSource failClick;

    private bool isAlive = true;

    private void Start()
    {
        currentOxygen = maxOxygen;
        oxygenTankIcon.fillAmount = 1f;
        UpdateUI();

        failClick = GetComponent<AudioSource>();

        skillCheck = FindAnyObjectByType<SkillCheckScript>();

        InvokeRepeating(nameof(DecreaseOxygenOverTime), decreaseInterval, decreaseInterval);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && skillCheck.checkActive == false)
        {
            DecreaseOxygen(decreaseAmount);
            failClick.Play();
        }
    }


    public float GetOxygen() => currentOxygen;

    public void DecreaseOxygenOverTime()
    {
        DecreaseOxygen(decreaseAmount);
    }

    public float SetOxygen(float _amount)
    {
        currentOxygen += _amount;
        // UI setzen
        return currentOxygen;
    }


    public bool DecreaseOxygen(float _amount)
    {
        if (isAlive)
        {
            currentOxygen -= _amount;
            if (currentOxygen <= 0)
            {
                currentOxygen = 0;
                isAlive = false;
            }
            UpdateUI();
        }
        return isAlive;
    }

    public void IncreaseOxygen(float _amount)
    {
        if (isAlive)
        {
            currentOxygen += _amount;
            if (currentOxygen > maxOxygen)
                currentOxygen = maxOxygen;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        oxygenText.text = currentOxygen.ToString();
        oxygenTankIcon.fillAmount = currentOxygen / maxOxygen;
    }

}
