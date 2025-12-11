# 🧭 Triply – AI-Generated Spontaneous Trip Planner  
### *Built with Unity + Firebase + iOS Deployment*

![banner](https://dummyimage.com/1200x250/1e2a47/ffffff&text=Triply+%E2%80%93+AI+Trip+Planner)

---

## 🔰 Badges

![Unity](https://img.shields.io/badge/Unity-2022+-black?logo=unity)
![Firebase](https://img.shields.io/badge/Firebase-Firestore-orange?logo=firebase)
![iOS](https://img.shields.io/badge/iOS-Build-blue?logo=apple)
![License](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Active-blue)

---

# 🌟 Overview

**Triply** is a mobile app that instantly generates personalized day trips based on user preferences.  
Built in **Unity**, powered by **Firebase Firestore** + **Firebase Auth**, and deployed to **iOS** via Xcode.

Users choose:
- Budget  
- Distance  
- Vibe  
- Starting location  

Then Triply returns a **complete Morning–Afternoon–Evening itinerary**.

---

# 🚀 Features

## 🔐 Authentication  
- Email/password login  
- Anonymous guest mode  
- Firebase Auth backend  

## 📝 Trip Planning  
User selects:
- **Starting Location**  
- **Budget:** low / medium / high  
- **Distance:** near / daytrip / far  
- **Vibe:** nature / food_city / culture  

## ✨ AI-Inspired Trip Generation  
- Pulls matching templates from Firestore  
- Picks one at random  
- Displays a beautifully formatted itinerary  

## 💾 Save Trips  
- Saves the generated trip to `savedTrips` collection  
- Displays saved trips in a scrollable card UI  

## 📱 iOS Support  
- Buildable via Unity → Xcode  
- Runs on physical iPhone  
- Uses `.xcworkspace` for CocoaPods

---

# 📁 Project Structure
Assets/
├── Scenes/
│    ├── StartupScene.unity
│    ├── LoginScene.unity
│    ├── PlanTripScene.unity
│    ├── TripResultsScene.unity
│    └── SavedTripsScene.unity
│
├── Scripts/
│    ├── TripCriteria.cs
│    ├── TripCriteriaManager.cs
│    ├── TripGeneratorUI.cs
│    ├── TripResultsUI.cs
│    ├── SavedTripCardUI.cs
│    ├── SavedTripsListUI.cs
│    ├── FirebaseInitializer.cs
│    └── TripTemplateSeeder.cs
│
├── Prefabs/
│    └── SavedTripCard.prefab
│
└── Firebase/
└── GoogleService-Info.plist

---

# 🔥 Firebase Setup Guide

## 1️⃣ Add an iOS App in Firebase Console  
- Bundle ID must match Unity project

## 2️⃣ Add GoogleService-Info.plist  
Place in:

# 🌱 Future Enhancements

- 🌄 **3D Interactive destination previews**  
- 🧠 **AI-generated itineraries**  
- 🌤️ **Weather + Maps integration**  
- 🌍 **Global destinations database**  
- ❤️ **User favorites / bookmarks**  
- 📤 **Social media trip sharing**

---

# 📄 License  
MIT License — open for student & personal use.

---

# 🙌 Credits

Developed by:  
**Rezwan** & **Htet**  
BMCC • CIS272
