using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillCheckScript : MonoBehaviour
{
    [Header("Timing")]
    [SerializeField] private float minInterval = 5f;     // Min-Wartezeit bis nächster Check
    [SerializeField] private float maxInterval = 15f;    // Max-Wartezeit
    [SerializeField] private float checkDuration = 3f;   // Dauer des einzelnen Skill-Checks

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI skillCheckText;
    [SerializeField] private Image progressBar;
    [SerializeField] private Image hoseBarCut;
    public bool checkActive {get; private set;}

    [Header("Key Label")]
    [SerializeField] private string keyPrompt = "Press SPACE!";

    private OxygenHandler oxygenHandler;

    AudioSource audioSource;
    [SerializeField] private AudioClip[] skillCheckSound;



    [Header("Tank System")]
    [SerializeField] TankScript[] tanks;
    private int tankNum = 0;

    private void Start()
    {
        // UI initial verstecken
        skillCheckText.gameObject.SetActive(false);
        progressBar.gameObject.SetActive(false);

        // Endlosschleife für zufällige Skill-Checks starten
        StartCoroutine(SkillCheckLoop());

        oxygenHandler = FindAnyObjectByType<OxygenHandler>();

        audioSource = GetComponent<AudioSource>();

        checkActive = false;

    }

    private IEnumerator SkillCheckLoop()
    {
        while (tankNum < 3)
        {
            // Warte zufällige Zeit bis zum nächsten Check
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            // Starte einzelnen Skill-Check
            yield return StartCoroutine(RunSingleSkillCheck());
        }
    }

    private IEnumerator RunSingleSkillCheck()
    {
        // UI einblenden
        skillCheckText.text = keyPrompt;
        skillCheckText.gameObject.SetActive(true);


        progressBar.fillAmount = 0f;                // startet leer
        progressBar.gameObject.SetActive(true);

        PlaySound(0);

        // Skill-Check Countdown
        float elapsed = 0f;
        bool success = false;

        while (elapsed < checkDuration && !success)
        {
            checkActive = true;
            // Bei Druck auf Leertaste erfolgreich
            if (Input.GetKeyDown(KeyCode.Space))
            {
                success = true;
                break;
            }

            // Zeit hochzählen und ProgressBar füllen
            elapsed += Time.deltaTime;
            progressBar.fillAmount = Mathf.Clamp01(elapsed / checkDuration);

            yield return null;
        }
        // UI wieder verstecken
        skillCheckText.gameObject.SetActive(false);
        progressBar.gameObject.SetActive(false);



        // Ergebnis auswerten
        if (success)
            OnSkillCheckSuccess();
        else
            OnSkillCheckFailure();
    }

    private void OnSkillCheckSuccess()
    {
        oxygenHandler.IncreaseOxygen(8f); // kann durch Random ersetzt werden
        StopSound(0);
        PlaySound(1);
        checkActive = false;
    }

    private void OnSkillCheckFailure()
    {
        oxygenHandler.DecreaseOxygen(15f); // kann durch Random ersetzt werden
        StopSound(0);
        if (tanks != null)
        {
            tanks[tankNum].LoseTank();
            tankNum++;
        }
        PlaySound(2);
        StartCoroutine(DisableCutBar());

        IEnumerator DisableCutBar()
        {
            hoseBarCut.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            hoseBarCut.gameObject.SetActive(false);
            checkActive = false;
        }
       
    }
    private void PlaySound(int soundNum)
    {
        audioSource.clip = skillCheckSound[soundNum];

        if (soundNum == 2)
        {
            audioSource.volume = .5f;
            audioSource.Play();
        }
        else
        {
            audioSource.Play();
        }

    }
    public void StopSound(int soundNum)
    {
        audioSource.clip = skillCheckSound[soundNum];
        audioSource.Stop();
    }
}
