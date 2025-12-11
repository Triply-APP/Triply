using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Firestore;

public class TripGeneratorUI : MonoBehaviour
{
    public TMP_InputField startingLocationInput;
    public TMP_Dropdown budgetDropdown;
    public TMP_Dropdown distanceDropdown;
    public TMP_Dropdown vibeDropdown;

    private FirebaseFirestore db;

    private void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
    }

    // Called by the Generate Trip button
    public void OnGenerateTripClicked()
    {
        string startingLocation = startingLocationInput != null
            ? startingLocationInput.text.Trim()
            : "";

        Debug.Log("[TripGeneratorUI] Starting location: " + startingLocation);

        // ✅ Do NOT load the scene here
        GenerateTripAsync();
    }

    // Does Firestore work, then loads TripResultsScene
    private async void GenerateTripAsync()
    {
        if (TripCriteriaManager.Instance == null)
        {
            Debug.LogError("[TripGeneratorUI] TripCriteriaManager.Instance is NULL!");
            return;
        }

        string budgetKey   = GetBudgetKey(budgetDropdown.value);
        string distanceKey = GetDistanceKey(distanceDropdown.value);
        string vibeKey     = GetVibeKey(vibeDropdown.value);

        Debug.Log($"[TripGeneratorUI] Querying with budget={budgetKey}, distance={distanceKey}, vibe={vibeKey}");

        Query query = db.Collection("tripTemplates")
            .WhereEqualTo("budgetKey", budgetKey)
            .WhereEqualTo("distanceKey", distanceKey)
            .WhereEqualTo("vibeKey", vibeKey);

        QuerySnapshot snapshot;
        try
        {
            snapshot = await query.GetSnapshotAsync();
        }
        catch (System.Exception e)
        {
            Debug.LogError("[TripGeneratorUI] Firestore query failed: " + e.Message);
            return;
        }

        var docs = snapshot.Documents.ToList();
        Debug.Log("[TripGeneratorUI] Docs found: " + docs.Count);

        if (docs.Count == 0)
        {
            Debug.LogWarning("[TripGeneratorUI] No trips found for selected criteria.");
            return;
        }

        // Pick random trip
        var chosen = docs[Random.Range(0, docs.Count)];
        var data = chosen.ToDictionary();

        TripPlan plan = new TripPlan
        {
            destination = data["destination"].ToString(),
            distance    = data["distance"].ToString(),
            morning  = new TimeBlock { description = data["morningDescription"].ToString() },
            afternoon= new TimeBlock { description = data["afternoonDescription"].ToString() },
            evening  = new TimeBlock { description = data["eveningDescription"].ToString() }
        };

        TripCriteriaManager.Instance.CurrentTripPlan = plan;

        Debug.Log("[TripGeneratorUI] TripPlan set – loading TripResultsScene");

        // ✅ Load the scene ONLY AFTER we have a plan
        SceneManager.LoadScene("TripResultsScene");   // make sure name matches your scene
    }

    private string GetBudgetKey(int index)
    {
        switch (index)
        {
            case 0: return "low";
            case 1: return "medium";
            case 2: return "high";
            default: return "medium";
        }
    }

    private string GetDistanceKey(int index)
    {
        switch (index)
        {
            case 0: return "near";
            case 1: return "daytrip";
            case 2: return "far";
            default: return "daytrip";
        }
    }

    private string GetVibeKey(int index)
    {
        switch (index)
        {
            case 0: return "nature";
            case 1: return "food_city";
            case 2: return "culture";
            default: return "nature";
        }
    }
}