using UnityEngine;
using TMPro;

public class TripResultsUI : MonoBehaviour
{
    [Header("Destination")]
    public TMP_Text destinationText;

    [Header("Distance")]
    public TMP_Text distance;   // Text for "60 miles • Day Trip"

    [Header("Morning")]
    public TMP_Text morningDescriptionText;

    [Header("Afternoon")]
    public TMP_Text afternoonDescriptionText;

    [Header("Evening")]
    public TMP_Text eveningDescriptionText;

    private void Start()
    {
        var plan = TripCriteriaManager.Instance.CurrentTripPlan;
        if (plan == null)
        {
            Debug.LogError("No TripPlan found. Did you come here through GenerateTrip?");
            if (destinationText != null)
                destinationText.text = "No trip loaded";
            return;
        }

        if (destinationText != null)
            destinationText.text = plan.destination;

        if (distance != null)
            distance.text = plan.distance;   // ⬅️ NEW: show distance text

        if (morningDescriptionText != null)
            morningDescriptionText.text = plan.morning.description;

        if (afternoonDescriptionText != null)
            afternoonDescriptionText.text = plan.afternoon.description;

        if (eveningDescriptionText != null)
            eveningDescriptionText.text = plan.evening.description;
    }
}