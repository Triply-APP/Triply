using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public void OnLoginButtonClicked()
    {
        string email = emailInput.text.Trim();
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("Email or password is empty.");
            // Later you can show a UI error message here
            return;
        }

        // TODO: real auth (Firebase, etc.) in future.
        Debug.Log($"Logged in as: {email}");

        // For now, just go to PlanTripScene
        SceneManager.LoadScene("PlanTripScene");
    }

    public void OnGuestButtonClicked()
    {
        Debug.Log("Continue as guest.");
        SceneManager.LoadScene("PlanTripScene");
    }
}
