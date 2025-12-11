using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class GenerateValidator : MonoBehaviour
{
    [Header("UI references")]
    public TMP_InputField emailInput;   // the email input field
    public TMP_Text errorText;         // the red error text to show/hide
    public Button generateButton;      // optional: the generate button

    [Header("Validation options")]
    public bool requireGmailOnly = true; // true => only accept addresses ending with @gmail.com

    void Start()
    {
        // ensure error text hidden at start
        if (errorText != null) errorText.gameObject.SetActive(false);

        // optionally hook up the button programmatically if you prefer
        if (generateButton != null)
        {
            generateButton.onClick.RemoveListener(OnGenerateClicked); // prevent double adding
            generateButton.onClick.AddListener(OnGenerateClicked);
        }
    }

    // Hook this to the button OnClick (or let Start add it via generateButton)
    public void OnGenerateClicked()
    {
        string email = (emailInput != null) ? emailInput.text.Trim() : "";

        bool ok = false;
        if (requireGmailOnly)
        {
            ok = IsValidGmail(email);
        }
        else
        {
            ok = IsValidEmail(email);
        }

        if (!ok)
        {
            // show the error
            if (errorText != null)
            {
                errorText.gameObject.SetActive(true);
                errorText.text = requireGmailOnly
                    ? "⚠ This is not a valid Gmail address (example: name@gmail.com)."
                    : "⚠ This is not a valid email address.";
            }

            // (Optional) set focus back to the email input:
            if (emailInput != null) emailInput.Select();
            return;
        }

        // Passed validation -> hide error and continue
        if (errorText != null) errorText.gameObject.SetActive(false);

        // TODO: proceed with generation logic here
        // Example: call your scene navigator, start generator coroutine, etc.
        Debug.Log("Email valid — proceed with Generate action.");
    }

    bool IsValidGmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;
        email = email.ToLowerInvariant();
        if (!email.EndsWith("@gmail.com")) return false;
        // Make sure there's something before the @ and no spaces
        int atIdx = email.IndexOf('@');
        if (atIdx <= 0) return false;
        // basic local part check
        return IsValidEmail(email);
    }

    bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;
        // very simple email regex (sufficient for UI validation)
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }
}
