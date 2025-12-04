using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void GoToStartup()
    {
        Debug.Log("GoToStartup called");
        SceneManager.LoadScene("StartupScene");
    }

    public void GoToPlanTrip()
    {
        Debug.Log("GoToPlanTrip called");
        SceneManager.LoadScene("PlanTripScene");
    }

    public void GoToResults()
    {
        Debug.Log("GoToResults called");
        SceneManager.LoadScene("TripResultsScene");
    }

    public void GoToSavedTrips()
    {
        Debug.Log("GoToSavedTrips called");
        SceneManager.LoadScene("SavedTripsScene");
    }
}