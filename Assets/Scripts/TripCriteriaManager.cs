using UnityEngine;

public class TripCriteriaManager : MonoBehaviour
{
    public static TripCriteriaManager Instance;

    public TripCriteria CurrentCriteria = new TripCriteria();
    public TripPlan CurrentTripPlan;

    void Awake()
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