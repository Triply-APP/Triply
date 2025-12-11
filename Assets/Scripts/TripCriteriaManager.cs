using UnityEngine;

[System.Serializable]
public class TimeBlock
{
    public string description;
}

[System.Serializable]
public class TripPlan
{
    public string destination;
    public string distance;   // e.g. "60 miles • Day Trip"
    public TimeBlock morning;
    public TimeBlock afternoon;
    public TimeBlock evening;
}

public class TripCriteriaManager : MonoBehaviour
{
    public static TripCriteriaManager Instance { get; private set; }

    // Auto-property: Unity will NOT show this in the Inspector
    public TripPlan CurrentTripPlan { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}