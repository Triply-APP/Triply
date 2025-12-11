using TMPro;
using UnityEngine;
using System;

public class TripCardUI : MonoBehaviour
{
    public TMP_Text destinationNameText;
    public TMP_Text dateDistanceText;   // this is your DistanceText
    public TMP_Text keywordsText;

    public void Setup(string destinationName, DateTime date, float miles, string[] tags)
    {
        destinationNameText.text = destinationName;
        dateDistanceText.text = $"{date:MMMM d, yyyy} • {miles:0} miles";
        keywordsText.text = string.Join(" | ", tags);
    }
}


/*From whatever script creates/populates your cards, call:
 cardUI.Setup(
    "Napa Valley",
    new DateTime(2025, 6, 15),
    85f,
    new[] { "Wine", "Luxury" }
);
*/