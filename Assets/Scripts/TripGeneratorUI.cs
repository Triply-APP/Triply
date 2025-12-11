using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Firestore;

public class TripGeneratorUI : MonoBehaviour
{
    [Header("Inputs")]
    public TMP_InputField startingLocationInput;    // Your "Starting Location" field
    public TMP_Dropdown budgetDropdown;            // Budget selector
    public TMP_Dropdown distanceDropdown;          // Distance selector
    public TMP_Dropdown vibeDropdown;              // Vibe selector

    private FirebaseFirestore db;

    private void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
    }

    // Hook this to your "Generate Trip" button OnClick
    public void OnGenerateTripClicked()
    {
        string startingLocation = startingLocationInput != null
            ? startingLocationInput.text.Trim()
            : "";

        Debug.Log("Starting location: " + startingLocation);

        GenerateTripAsync();
    }

    private async void GenerateTripAsync()
    {
        // 1. Convert dropdown selections → Firestore keys
        string budgetKey = GetBudgetKey(budgetDropdown.value);
        string distanceKey = GetDistanceKey(distanceDropdown.value);
        string vibeKey = GetVibeKey(vibeDropdown.value);

        Debug.Log($"Querying Firestore with budget={budgetKey}, distance={distanceKey}, vibe={vibeKey}");

        // 2. Build Firestore query
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
            Debug.LogError("Firestore query failed: " + e.Message);
            return;
        }

        var docs = snapshot.Documents.ToList();  // Convert IEnumerable → List

        if (docs.Count == 0)
        {
            Debug.LogWarning("No trips found for selected criteria.");
            return;
        }

        // 3. Pick a random document
        int index = Random.Range(0, docs.Count);
        DocumentSnapshot chosen = docs[index];
        var data = chosen.ToDictionary();

        // 4. Build TripPlan from document fields
        TripPlan plan = new TripPlan
        {
            destination = data.ContainsKey("destination") ? data["destination"].ToString() : "Unknown destination",
            distance    = data.ContainsKey("distance")    ? data["distance"].ToString()    : "",

            morning = new TimeBlock
            {
                description = data.ContainsKey("morningDescription")
                    ? data["morningDescription"].ToString()
                    : ""
            },
            afternoon = new TimeBlock
            {
                description = data.ContainsKey("afternoonDescription")
                    ? data["afternoonDescription"].ToString()
                    : ""
            },
            evening = new TimeBlock
            {
                description = data.ContainsKey("eveningDescription")
                    ? data["eveningDescription"].ToString()
                    : ""
            }
        };

        if (TripCriteriaManager.Instance == null)
        {
            Debug.LogError("TripCriteriaManager.Instance is null. Make sure it exists in an earlier scene.");
            return;
        }

        // 5. Store result globally and go to TripResultsScene
        TripCriteriaManager.Instance.CurrentTripPlan = plan;

        SceneManager.LoadScene("TripResultsScene");
    }

    // 🔻 These assume your dropdown options are ordered (0,1,2). Adjust if needed.

    private string GetBudgetKey(int index)
    {
        // index 0 = Low, 1 = Medium, 2 = High
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
        // index 0 = Nearby, 1 = Day Trip, 2 = Far
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
        // index 0 = Nature, 1 = Food/City, 2 = Culture
        switch (index)
        {
            case 0: return "nature";
            case 1: return "food_city";
            case 2: return "culture";
            default: return "nature";
        }
    }
}