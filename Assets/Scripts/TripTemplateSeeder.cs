using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

public class TripTemplateSeeder : MonoBehaviour
{
    [Tooltip("Set true → press Play ONCE → then disable")]
    public bool runOnStart = true;

    private FirebaseFirestore db;

    private async void Start()
    {
        if (!runOnStart) return;

        db = FirebaseFirestore.DefaultInstance;
        await SeedAllTemplatesAsync();
    }

    private async System.Threading.Tasks.Task SeedAllTemplatesAsync()
    {
        Debug.Log("Seeding multiple trip templates to Firestore...");

        var trips = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object>
{
    { "destination", "Cold Spring, NY" },
    { "distance", "60 miles • Day Trip" },
    { "budgetKey", "low" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "nature" },
    { "morningDescription", "Stroll along the Hudson riverfront and enjoy coffee at a cozy riverside café before the crowds arrive." },
    { "afternoonDescription", "Explore antique shops on Main Street and grab lunch with mountain-ridge views." },
    { "eveningDescription", "Watch the sunset over the river from the docks, with quiet calm and gentle water breeze." }
},

new Dictionary<string, object>
{
    { "destination", "Beacon, NY" },
    { "distance", "70 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "culture" },
    { "morningDescription", "Visit the modern art museum when it opens — calm exhibits and good lighting." },
    { "afternoonDescription", "Walk around Main Street, check local art galleries and try a farm-to-table lunch." },
    { "eveningDescription", "Relax by a local brewery or cafe, enjoy mellow music and nightlife ambiance." }
},

new Dictionary<string, object>
{
    { "destination", "Bear Mountain State Park, NY" },
    { "distance", "50 miles • Day Trip" },
    { "budgetKey", "low" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "nature" },
    { "morningDescription", "Morning hike on a shaded forest trail, fresh mountain air and bird songs." },
    { "afternoonDescription", "Picnic by the lake and enjoy panoramic ridgeline views with sun filtering through trees." },
    { "eveningDescription", "Chill at a scenic overlook while golden light bathes the valley — perfect for photos." }
},

new Dictionary<string, object>
{
    { "destination", "Hudson River Greenway, NYC" },
    { "distance", "5 miles • Nearby" },
    { "budgetKey", "low" },
    { "distanceKey", "near" },
    { "vibeKey", "nature" },
    { "morningDescription", "Start the day with a calm riverside walk or jog, with fresh air and skyline views." },
    { "afternoonDescription", "Relax by benches along the water, grab street food and watch boats go by." },
    { "eveningDescription", "Sunset glows over the water — great time for a stroll or casual picnic on the riverbank." }
},

new Dictionary<string, object>
{
    { "destination", "Rockaway Beach, Queens, NYC" },
    { "distance", "15 miles • Nearby" },
    { "budgetKey", "low" },
    { "distanceKey", "near" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Walk along the boardwalk with soft ocean breeze and early-morning calm." },
    { "afternoonDescription", "Snack on beach-side vendors, enjoy sun and surf, maybe grab a casual lunch." },
    { "eveningDescription", "Boardwalk lights, seafood dinner and chill seaside atmosphere under the stars." }
},

new Dictionary<string, object>
{
    { "destination", "Long Beach, NY" },
    { "distance", "25 miles • Nearby" },
    { "budgetKey", "medium" },
    { "distanceKey", "near" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Beachfront walk at sunrise and breakfast at a local café by the sea." },
    { "afternoonDescription", "Sunbathing or swimming, followed by boardwalk snacks and ice-cream." },
    { "eveningDescription", "Relaxing seaside dinner and waves lapping under sunset sky." }
},

new Dictionary<string, object>
{
    { "destination", "Asbury Park, NJ" },
    { "distance", "70 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Vintage cafés and seaside breeze set a relaxing start by the boardwalk." },
    { "afternoonDescription", "Explore street art, shops, and have lunch near the beach pier." },
    { "eveningDescription", "Live music venues, boardwalk lights, and a lively but chill beach-town vibe." }
},

new Dictionary<string, object>
{
    { "destination", "Fire Island, NY" },
    { "distance", "90 miles • Far" },
    { "budgetKey", "medium" },
    { "distanceKey", "far" },
    { "vibeKey", "nature" },
    { "morningDescription", "Sunrise beach walk and soft sound of waves on sand for a peaceful start." },
    { "afternoonDescription", "Bike along the boardwalk, explore dunes, maybe grab seaside lunch." },
    { "eveningDescription", "Beach bonfire (if permitted) or watch the sunset over the Atlantic — calm and serene." }
},

new Dictionary<string, object>
{
    { "destination", "Hudson Valley – Small Town Food & Shops Tour" },
    { "distance", "80 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Start with a cozy brunch at a local bakery in a charming small town." },
    { "afternoonDescription", "Walk boutique streets, sample local treats and shop handmade crafts." },
    { "eveningDescription", "Dinner at a farm-to-table restaurant, enjoy sunset vibes and local ambiance." }
},

new Dictionary<string, object>
{
    { "destination", "Historic Waterfront Town (Hudson Region)" },
    { "distance", "95 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "culture" },
    { "morningDescription", "Quiet harbor walk and historic buildings in soft morning light." },
    { "afternoonDescription", "Visit local museums or galleries and enjoy waterfront lunch." },
    { "eveningDescription", "Street-lamp walks by the water and relaxed dinner with local cuisine." }
},new Dictionary<string, object>
{
    { "destination", "Mohonk Preserve / New Paltz, NY" },
    { "distance", "120 miles • Far" },
    { "budgetKey", "low" },
    { "distanceKey", "far" },
    { "vibeKey", "nature" },
    { "morningDescription", "Forest trail hike with fresh air, birds chirping and mountain views." },
    { "afternoonDescription", "Picnic by lakeside or valley, enjoying natural sounds and calm atmosphere." },
    { "eveningDescription", "Relax by the lodge or lookout point with sunset over ridges — serene nature ending." }
},

new Dictionary<string, object>
{
    { "destination", "Catskills Region, NY — Waterfall & Trails" },
    { "distance", "140 miles • Far" },
    { "budgetKey", "low" },
    { "distanceKey", "far" },
    { "vibeKey", "nature" },
    { "morningDescription", "Morning hike to waterfalls under mist and forest canopy quietness." },
    { "afternoonDescription", "Lunch in small-town cafés, followed by scenic drives through mountain roads." },
    { "eveningDescription", "Sunset from a lookout, cool breeze, and peaceful mountain air before return." }
},

new Dictionary<string, object>
{
    { "destination", "Sleepy Hollow / Tarrytown, NY" },
    { "distance", "40 miles • Day Trip" },
    { "budgetKey", "low" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "culture" },
    { "morningDescription", "Stroll historic town streets and old houses under soft daylight." },
    { "afternoonDescription", "Visit historic sites, museums or RiverWalk with riverside lunch." },
    { "eveningDescription", "Riverside sunset walk and cozy dinner in local pub — calm and nostalgic vibe." }
},

new Dictionary<string, object>
{
    { "destination", "Beacon & Hudson Highlands, NY" },
    { "distance", "75 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "nature" },
    { "morningDescription", "Train ride north and riverside walk before town wakes up." },
    { "afternoonDescription", "Scenic hike in Hudson Highlands with views over the Hudson River." },
    { "eveningDescription", "Return to town for dinner and sunset reflections over water — tranquil blend of nature + culture." }
},

new Dictionary<string, object>
{
    { "destination", "Rockland County Mountain Viewpoint, NY" },
    { "distance", "45 miles • Day Trip" },
    { "budgetKey", "low" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "nature" },
    { "morningDescription", "Quiet trail walk in the woods with morning dew and bird sounds." },
    { "afternoonDescription", "Picnic on a mountain overlook with green valleys beneath." },
    { "eveningDescription", "Golden-hour view over hills and peaceful return drive with sunset sky." }
},

new Dictionary<string, object>
{
    { "destination", "North-South Lake (Catskills), NY" },
    { "distance", "130 miles • Far" },
    { "budgetKey", "low" },
    { "distanceKey", "far" },
    { "vibeKey", "nature" },
    { "morningDescription", "Lakeside sunrise, calm waters, mist over the lake and fresh air." },
    { "afternoonDescription", "Swim or kayak, forest trails, or simple rest under trees by water." },
    { "eveningDescription", "Campfire by the shore or quiet lakeside sunset — perfect nature retreat." }
},

new Dictionary<string, object>
{
    { "destination", "High Tor State Park, NY" },
    { "distance", "50 miles • Day Trip" },
    { "budgetKey", "low" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "nature" },
    { "morningDescription", "Cool morning hike up to the peak with clear skies and valley views." },
    { "afternoonDescription", "Picnic and river-view rest spots with gentle breeze and sunlight." },
    { "eveningDescription", "Watch sunset from ridgeline — valley glows under twilight and calm air sets in." }
},

new Dictionary<string, object>
{
    { "destination", "Waterfront Harbor Town (NJ Shore)" },
    { "distance", "80 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Seaside breakfast near the pier and soft sea breeze for a calm start." },
    { "afternoonDescription", "Explore shops, local markets, and enjoy fresh seafood for lunch." },
    { "eveningDescription", "Boardwalk stroll at dusk, lights reflecting on water, relaxing beach dinner." }
},

new Dictionary<string, object>
{
    { "destination", "Long Island Beach Escape, NY" },
    { "distance", "60 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "nature" },
    { "morningDescription", "Beach sunrise walk, calm waves and soft sand underfoot." },
    { "afternoonDescription", "Relaxation by the sea, maybe swim or read a book by water, light lunch." },
    { "eveningDescription", "Bonfire (if permitted) or sunset walk with salty breeze and ocean sounds." }
},

new Dictionary<string, object>
{
    { "destination", "Island Ferry & Coastal Town Tour, NY" },
    { "distance", "95 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "culture" },
    { "morningDescription", "Ferry ride with cool water air and skyline views before arrival." },
    { "afternoonDescription", "Explore coastal town — shops, cafés, historic streets by the sea." },
    { "eveningDescription", "Dinner by the harbor and sunset view over the ocean setting the mood." }
},

new Dictionary<string, object>
{
    { "destination", "Small Mountains & Vineyards Region, NY" },
    { "distance", "110 miles • Day Trip" },
    { "budgetKey", "high" },
    { "distanceKey", "far" },
    { "vibeKey", "nature" },
    { "morningDescription", "Scenic vineyard stroll and fresh grape-vine scents in early light." },
    { "afternoonDescription", "Wine tasting, countryside lunch and gentle valley walks under calm sun." },
    { "eveningDescription", "Sunset over vineyards and tranquil drive back under starlight skies." }
},

new Dictionary<string, object>
{
    { "destination", "Historic Town & Artisanal Shops Tour, NY" },
    { "distance", "85 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "culture" },
    { "morningDescription", "Antique stores and artsy cafés give a relaxed vibe for morning stroll." },
    { "afternoonDescription", "Local art galleries, hand-craft shops, and cultural exhibits in town center." },
    { "eveningDescription", "Candle-lit dinner at a cozy inn and evening walk on historic streets." }
},

new Dictionary<string, object>
{
    { "destination", "State Park Waterfalls & Forest Hike, NY" },
    { "distance", "120 miles • Far" },
    { "budgetKey", "low" },
    { "distanceKey", "far" },
    { "vibeKey", "nature" },
    { "morningDescription", "Forest trail walk with birds, rivers flowing, and fresh air start." },
    { "afternoonDescription", "Waterfall viewpoint and riverside rest under trees and calm shade." },
    { "eveningDescription", "Quiet drive back home under dusk skies, nature still in the mind." }
},

new Dictionary<string, object>
{
    { "destination", "Riverfront Town & Local Markets, NY" },
    { "distance", "70 miles • Day Trip" },
    { "budgetKey", "low" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Morning stroll by the river, local bakery breakfast and calm waters." },
    { "afternoonDescription", "Street food markets and small-town shops creating vibrant local feel." },
    { "eveningDescription", "Local pub dinner with river-view twilight and cozy small-town charm." }
},

new Dictionary<string, object>
{
    { "destination", "Beach & Surf Town Escape, NJ/NY Shore" },
    { "distance", "90 miles • Far" },
    { "budgetKey", "medium" },
    { "distanceKey", "far" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Early beach walk and ocean breeze waking up by the sea." },
    { "afternoonDescription", "Surf or relax on the sand, enjoy seafood by the shore for lunch." },
    { "eveningDescription", "Boardwalk lights, seaside dinner, and waves under moonlight — chill night out." }
},

new Dictionary<string, object>
{
    { "destination", "Art & Culture Weekend Town, NY" },
    { "distance", "100 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "culture" },
    { "morningDescription", "Historic architecture and museum visits with calm early crowds." },
    { "afternoonDescription", "Local cultural exhibits, street art, and gallery browsing mid-day." },
    { "eveningDescription", "Live music or local show and cozy dinner under soft street lights." }
},

new Dictionary<string, object>
{
    { "destination", "Lake & Forest Retreat, Upstate NY" },
    { "distance", "150 miles • Far" },
    { "budgetKey", "low" },
    { "distanceKey", "far" },
    { "vibeKey", "nature" },
    { "morningDescription", "Lake-side sunrise, mist on water and calm natural scenery." },
    { "afternoonDescription", "Kayak or walk by the water, gentle breeze and forest shade." },
    { "eveningDescription", "Campfire by the lake, starry sky and tranquil sounds of nature." }
},

new Dictionary<string, object>
{
    { "destination", "Luxury Mountain Resort Trip, NY" },
    { "distance", "200 miles • Far" },
    { "budgetKey", "high" },
    { "distanceKey", "far" },
    { "vibeKey", "nature" },
    { "morningDescription", "Private resort sunrise with valley views, quiet and peaceful start." },
    { "afternoonDescription", "Spa, guided hikes, and relaxed lounge with scenic surroundings." },
    { "eveningDescription", "Fine dining and fireplace ambiance under mountain night sky." }
},

new Dictionary<string, object>
{
    { "destination", "City + Shore Combo Escape, NY/NJ" },
    { "distance", "95 miles • Day Trip" },
    { "budgetKey", "high" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Urban breakfast, then drive or train to the coast for beach time." },
    { "afternoonDescription", "Boardwalk lunch, seaside strolls, and coastal sun exposure." },
    { "eveningDescription", "Dinner by the sea and driving back under twilight skies — city & nature in one day." }
},

new Dictionary<string, object>
{
    { "destination", "Countryside Wine & Hiking Trip, NY" },
    { "distance", "130 miles • Far" },
    { "budgetKey", "high" },
    { "distanceKey", "far" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Vineyard tour start, tasting local wines and rural breakfast vibes." },
    { "afternoonDescription", "Countryside hiking with vineyard overlooks and gentle trails." },
    { "eveningDescription", "Sunset over vineyards and rustic dinner — calm, scenic and refined." }
},

new Dictionary<string, object>
{
    { "destination", "Historic Village & Artisan Shops, NY" },
    { "distance", "80 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "culture" },
    { "morningDescription", "Cobblestone streets and antique-shop browsing with small-town charm." },
    { "afternoonDescription", "Local crafts, handmade souvenirs, and vintage cafés for lunch." },
    { "eveningDescription", "Quiet dinner at a historic tavern and evening stroll under soft lights." }
},

new Dictionary<string, object>
{
    { "destination", "Mountain Ridge View Lookout, NY" },
    { "distance", "55 miles • Day Trip" },
    { "budgetKey", "low" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "nature" },
    { "morningDescription", "Early ridge hike with panoramic valley views under fresh air." },
    { "afternoonDescription", "Forest walk, rest by rock overlooks, and serene natural ambiance." },
    { "eveningDescription", "Golden-hour descent and calm countryside drive back home." }
},

new Dictionary<string, object>
{
    { "destination", "Seaside Town & Pier Walk, NY/NJ Shore" },
    { "distance", "85 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "food_city" },
    { "morningDescription", "Beachfront breakfast café near the pier, soft waves and morning calm." },
    { "afternoonDescription", "Explore pier shops, grab seafood lunch, enjoy boardwalk energy." },
    { "eveningDescription", "Sunset stroll on the beach and dinner with ocean breeze — relaxed coastal vibe." }
},

new Dictionary<string, object>
{
    { "destination", "Rolling Hills & Farm-to-Table Town, NY" },
    { "distance", "100 miles • Day Trip" },
    { "budgetKey", "medium" },
    { "distanceKey", "daytrip" },
    { "vibeKey", "culture" },
    { "morningDescription", "Morning farmers’ market and artisanal bakery shopping in small town center." },
    { "afternoonDescription", "Local craft distillery or winery visit with countryside views." },
    { "eveningDescription", "Rustic dinner with fresh local produce and peaceful countryside dusk." }
}
        };

        int count = 0;
        foreach (var trip in trips)
        {
            await db.Collection("tripTemplates").AddAsync(trip);
            count++;
        }

        Debug.Log($"✅ Finished seeding {count} trips!");
    }
}