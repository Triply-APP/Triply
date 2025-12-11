using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplaceActivityButton : MonoBehaviour
{
    [Header("Assign the Replace button here")]
    public Button replaceButton;

    [Header("Scene to load")]
    public string planTripScene = "PlanTripScene"; // Make sure this matches your actual scene name

    private void Start()
    {
        if (replaceButton != null)
        {
            replaceButton.onClick.AddListener(OnReplacePressed);
        }
        else
        {
            Debug.LogError("Replace button is not assigned on: " + gameObject.name);
        }
    }

    private void OnReplacePressed()
    {
        Debug.Log("Replace clicked! Opening plan trip page...");
        SceneManager.LoadScene(planTripScene);
    }
}
