using System.Threading.Tasks;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;

public class FirebaseInitializer : MonoBehaviour
{
    public static FirebaseInitializer Instance { get; private set; }

    public FirebaseAuth Auth { get; private set; }
    public FirebaseFirestore Firestore { get; private set; }
    public FirebaseUser CurrentUser { get; private set; }

    private async void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        await InitializeFirebase();
    }

    private async Task InitializeFirebase()
    {
        var dependencyStatus = await FirebaseApp.CheckAndFixDependenciesAsync();
        if (dependencyStatus != DependencyStatus.Available)
        {
            Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            return;
        }

        Auth = FirebaseAuth.DefaultInstance;
        Firestore = FirebaseFirestore.DefaultInstance;

        await SignInAnonymouslyIfNeeded();
    }

    private async Task SignInAnonymouslyIfNeeded()
    {
        if (Auth.CurrentUser == null)
        {
            var result = await Auth.SignInAnonymouslyAsync();
            CurrentUser = result.User;
            Debug.Log("Signed in anonymously as: " + CurrentUser.UserId);
        }
        else
        {
            CurrentUser = Auth.CurrentUser;
            Debug.Log("Already signed in as: " + CurrentUser.UserId);
        }
    }
}