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
    public TextMeshProUGUI titleText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set initial text value
        UpdateText(slider.value);

        // Subscribe to value change event
        slider.onValueChanged.AddListener(UpdateText);

        //button = GetComponent<Button>();
       // button = GameObject.Find("Start Game").GetComponent<Button>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        difficulty = (int)slider.value;

       // button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficulty()
    {
        startButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
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
