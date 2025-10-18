using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DifficultyLevel : MonoBehaviour
{
    [SerializeField] private Slider slider;          // Reference to the Slider
    [SerializeField] private TextMeshProUGUI valueText; // Reference to the TMP Text
    private Button button; // Reference to the Button
    private GameManager gameManager;
    public int difficulty;
    public Button startButton;
    public Button restartButton;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI instructionsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set initial text value
        UpdateText(slider.value);

        // Subscribe to value change event
        slider.onValueChanged.AddListener(UpdateText);
              
        difficulty = (int)slider.value;
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficulty()
    {
        startButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);    
        restartButton.gameObject.SetActive(true);
        FindFirstObjectByType<GameManager>().StartGame(difficulty);
       
    }
    private void UpdateText(float value)
    {
        // Format however you like
        valueText.text = value.ToString("0");
        difficulty = (int)value;
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        slider.onValueChanged.RemoveListener(UpdateText);
    }
}
