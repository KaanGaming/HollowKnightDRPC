using Modding;
using System.Collections.Generic;

namespace HollowKnightDRPC
{
    public partial class HollowKnightDRPC
    {
        public List<IMenuMod.MenuEntry> GetMenuData(IMenuMod.MenuEntry? toggleButtonEntry)
        {
            return new List<IMenuMod.MenuEntry>
            {
                new IMenuMod.MenuEntry(
                    "     § Main Settings", new string[] {""}, "...main settings.",
                    (int v) => { },
                    () => { return 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "Always Show Completion", new string[] {"Off", "On"}, "Always show your completion percentage",
                    (int v) => { Settings.AlwaysShowCompletion = v == 1 ? true : false; },
                    () => { return Settings.AlwaysShowCompletion ? 1 : 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "Show Total Save Time", new string[] {"Off", "On"}, "Show how much time you spent on your save",
                    (int v) => { Settings.ShowTotalSaveTime = v == 1 ? true : false; },
                    () => { return Settings.ShowTotalSaveTime ? 1 : 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "Use % for Boss HP", new string[] {"Off", "On"}, "Uses % to display Boss HP instead of numbers",
                    (int v) => { Settings.BossHPShowPercentage = v == 1 ? true : false; },
                    () => { return Settings.BossHPShowPercentage ? 1 : 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "     § Challenges", new string[] {""}, "Display challenges that you're doing in your profile",
                    (int v) => { },
                    () => { return 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "Boss Timer", new string[] {"W.I.P"}, "Timer for boss battles, replaces HP display (Coming soon)",
                    (int v) => { },
                    () => { return 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "Count Hits", new string[] {"Off", "On"}, "Counts every hit you get as 1 (Hit Alt+R to reset)",
                    (int v) =>
                    {
                        Settings.CountTakenHits = v == 1 ? true : false;
                    },
                    () =>
                    {
                        return Settings.CountTakenHits ? 1 : 0;
                    }
                    ),
                new IMenuMod.MenuEntry(
                    "     § Stats Row Customization", new string[] {""}, "Some features may be missing",
                    (int v) => { },
                    () => { return 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "1st display", new string[] {"None", "HP", "Geo", "Completion", "Soul", "J.Entry Count", "Relics", "Grubs", "Simple Key", "Elegant Key", "Love Key", "Shopkeeper's Key", "City Crest", "King's Brand", "Tram Pass", "Lantern", "Map&Quill", "Map Count", "Hunter's Journal", "Hunter's Mark", "Flower", "Godtuner", "Shard Count", "Fragment Count", "Soul Vessels", "Salubra's Blessing", "Pale Ore", "Essence", "Rancid Egg", "W.Journal", "H.Seal", "King's Idol", "Arcane Egg"}, "(Default: HP)",
                    (int v) => { Settings.StatsRow1 = v; },
                    () => { return Settings.StatsRow1; }
                    ),
                new IMenuMod.MenuEntry(
                    "2nd display", new string[] {"None", "HP", "Geo", "Completion", "Soul", "J.Entry Count", "Relics", "Grubs", "Simple Key", "Elegant Key", "Love Key", "Shopkeeper's Key", "City Crest", "King's Brand", "Tram Pass", "Lantern", "Map&Quill", "Map Count", "Hunter's Journal", "Hunter's Mark", "Flower", "Godtuner", "Shard Count", "Fragment Count", "Soul Vessels", "Salubra's Blessing", "Pale Ore", "Essence", "Rancid Egg", "W.Journal", "H.Seal", "King's Idol", "Arcane Egg"}, "(Default: Geo)",
                    (int v) => { Settings.StatsRow2 = v; },
                    () => { return Settings.StatsRow2; }
                    ),
                new IMenuMod.MenuEntry(
                    "3rd display", new string[] {"None", "HP", "Geo", "Completion", "Soul", "J.Entry Count", "Relics", "Grubs", "Simple Key", "Elegant Key", "Love Key", "Shopkeeper's Key", "City Crest", "King's Brand", "Tram Pass", "Lantern", "Map&Quill", "Map Count", "Hunter's Journal", "Hunter's Mark", "Flower", "Godtuner", "Shard Count", "Fragment Count", "Soul Vessels", "Salubra's Blessing", "Pale Ore", "Essence", "Rancid Egg", "W.Journal", "H.Seal", "King's Idol", "Arcane Egg"}, "(Default: Completion)",
                    (int v) => { Settings.StatsRow3 = v; },
                    () => { return Settings.StatsRow3; }
                    ),
                new IMenuMod.MenuEntry(
                    "     § Other", new string[] {""}, "",
                    (int v) => { },
                    () => { return 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "Hide Location", new string[] {"Off", "On"}, "Hides your location in Rich Presence",
                    (int v) => { Settings.HideLocation = v == 1 ? true : false; },
                    () => { return Settings.HideLocation ? 1 : 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "Hide Stats", new string[] {"Off", "On"}, "Hides your stats in Rich Presence",
                    (int v) => { Settings.HideStats = v == 1 ? true : false; },
                    () => { return Settings.HideStats ? 1 : 0; }
                    ),
                new IMenuMod.MenuEntry(
                    "Hide Everything", new string[] {"Off", "On", "ABSOLUTELY YES"}, "Except the elapsed time",
                    (int v) =>
                    {
                        if (v == 2) { Settings.HideEverything = true; Settings.HideAbsolutelyEverything = true; }
                        else Settings.HideEverything = v == 1 ? true : false;
                    },
                    () =>
                    {
                        if (Settings.HideAbsolutelyEverything) return 2;
                        return Settings.HideEverything ? 1 : 0;
                    }
                    )
            };
        }

        public bool ToggleButtonInsideMenu => false;
    }
}
