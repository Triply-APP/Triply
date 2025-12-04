[System.Serializable]
public class TripCriteria
{
    public string startingLocation;
    public string budget;
    public string distance;
    public string vibe;
}

[System.Serializable]
public class TripActivity
{
    public string label;
    public string description;
}

[System.Serializable]
public class TripPlan
{
    public string destination;
    public TripActivity morning;
    public TripActivity afternoon;
    public TripActivity evening;
}