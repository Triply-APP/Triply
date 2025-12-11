using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TripCardButton : MonoBehaviour
{
    [Header("Assign your Go button here")]
    public Button goButton;

    [Header("Name of the scene to load")]
    public string TripResultsScene = "TripResultsScene";

    private void Start()
    {
        // Add click listener
        if (goButton != null)
        {
            goButton.onClick.AddListener(OnGoPressed);
        }
        else
        {
            Debug.LogError("Go Button not assigned on: " + gameObject.name);
        }
    }

    private void OnGoPressed()
    {
        Debug.Log("Loading trip results from: " + gameObject.name);
        SceneManager.LoadScene(TripResultsScene);
    }
}
