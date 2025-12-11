using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LoginManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text emailErrorText;

    [Header("Settings")]
    public string nextScene = "PlanTripScene";

    private void Start()
    {
        if (emailErrorText != null)
            emailErrorText.gameObject.SetActive(false);
    }

    public void OnLoginButtonClicked()
    {
        string email = emailInput.text.Trim();
        string password = passwordInput.text.Trim();

        // Validate Email
        if (!IsValidEmail(email))
        {
            ShowError("Invalid email address");
            return;
        }

        // Validate Password
        if (string.IsNullOrEmpty(password))
        {
            ShowError("Password cannot be empty");
            return;
        }

        // All good → Load next scene
        HideError();
        Debug.Log("Login successful: " + email);
        SceneManager.LoadScene(nextScene);
    }

    public void OnGuestButtonClicked()
    {
        HideError();
        Debug.Log("Continue as guest.");
        SceneManager.LoadScene(nextScene);
    }

    private bool IsValidEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }

    private void ShowError(string msg)
    {
        emailErrorText.text = msg;
        emailErrorText.gameObject.SetActive(true);
    }

    private void HideError()
    {
        emailErrorText.gameObject.SetActive(false);
    }
}
