using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding;

namespace HollowKnightDRPC
{
    /// <summary>
    /// Room Names class.
    /// <br />
    /// If interested to add custom friendly scene names, use <see cref="RoomNamesHelper"/>.
    /// </summary>
    public static class RoomNames
    {
        public static string GetRoomName(string scene)
        {
            #region Endings
            if (scene == "Cinematic_Ending_A")
                return "Hollow Knight Ending";
            if (scene == "Cinematic_Ending_B")
                return "Sealed Siblings Ending";
            if (scene == "Cinematic_Ending_C")
                return "Dream No More Ending";
            if (scene == "Cinematic_Ending_D")
                return "Embrace The Void Ending";
            if (scene == "Cinematic_Ending_E")
                return "Embrace The Void Ending";
            #endregion

            #region Other
            if (scene == "Cinematic_MrMushroom")
                return "Mr. Mushroom's Wild Return";
            if (scene == "Cinematic_Stag_Travel")
                return "Travelling on Stag";
            if (scene == "End_Credits")
                return "Watching the Credits";
            if (scene == "Quit_To_Menu")
                return "Quitting to Menu";
            #endregion

            #region Dirtmouth
            if (scene == "Tutorial_01")
                return "King's Pass";
            if (scene == "Town")
                return "Dirtmouth";
            if (scene == "Room_shop")
                return "Dirtmouth - Sly's Shop";
            if (scene == "Room_Sly_storeroom")
                return "Dirtmouth - Sly's Basement";
            if (scene == "Room_Town_Stag_Station")
                return "Dirtmouth - Stag Station";
            if (scene == "Room_mapper")
                return "Dirtmouth - Iselda's Shop";
            if (scene == "Room_Bretta")
                return "Dirtmouth - Bretta's House";
            if (scene == "Room_Bretta_Basement")
                return "Dirtmouth - Bretta's Basement";
            if (scene == "Room_Ouiji")
                return "Dirtmouth - Jiji The Confessor's House";
            if (scene == "Room_Jinn")
                return "Dirtmouth - Steel Soul Jinn's House";
            #endregion

            #region Forgotten Crossroads
            if (scene == "Crossroads_01")
                return "Forgotten Crossroads - Into the Well";
            if (scene == "Crossroads_02")
                return "Forgotten Crossroads - Outside of Temple";
            if (scene == "Room_temple")
                return "Forgotten Crossroads - Black Egg Temple";
            if (scene == "Room_Charm_Shop")
                return "Forgotten Crossroads - Salubra The Charmlover's Shop";
            if (scene == "Crossroads_03")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_04")
                return "Forgotten Crossroads - Against the Gruz Mother";
            if (scene == "Crossroads_05")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_06")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_07")
                return "Forgotten Crossroads - Lotsa Gruzzers";
            if (scene == "Crossroads_08")
                return "Forgotten Crossroads";
            if (scene == "Room_Tram_RG")
                return "Inside Tram (To FC/RG)";
            if (scene == "Crossroads_09")
                return "Forgotten Crossroads - Against the Brooding Mawlek";
            if (scene == "Crossroads_10")
                return "Forgotten Crossroads - Against the False Knight";
            if (scene == "Crossroads_11_alt")
                return "Greenpath - Entrance";
            if (scene == "Crossroads_12")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_13")
                return "Forgotten Crossroads - Kinda... Goamy here";
            if (scene == "Crossroads_14")
                return "Forgotten Crossroads - Crystal Entrance";
            if (scene == "Crossroads_15")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_16")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_17")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_18")
                return "Forgotten Crossroads - Feelin' kinda fungi,";
            if (scene == "Crossroads_19")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_21")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_22")
                return "Forgotten Crossroads - Not Alone, Anymore";
            if (scene == "Crossroads_25")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_27")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_30")
                return "Forgotten Crossroads - Hot Spring";
            if (scene == "Crossroads_31")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_33")
                return "Forgotten Crossroads - Not Lost Anymore (feat. Cornifer)";
            if (scene == "Crossroads_35")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_36")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_37")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_38")
                return "Forgotten Crossroads - Grubby, Grub and Grubfather (" + PlayerData.instance.grubsCollected + " grubs collected)";
            if (scene == "Crossroads_39")
                return "Forgotten Crossroads - Past the Temple...";
            if (scene == "Crossroads_40")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_42")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_43")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_45")
            {
                int infectedLevel = 0;
                if (PlayerData.instance.statueStateSoulMaster.isUnlocked)
                {
                    infectedLevel = 1;
                }
                if (PlayerData.instance.hasSuperDash) infectedLevel = 2;
                if (infectedLevel == 0) return "Forgotten Crossroads - Myla";
                else if (infectedLevel == 1) return "Forgotten Crossroads - Myla?";
                else return "Forgotten Crossroads - Husk Miner";
            }
            if (scene == "Crossroads_46")
                return "Forgotten Crossroads - Tram Station";
            if (scene == "Crossroads_47")
                return "Forgotten Crossroads - Stag Station";
            if (scene == "Crossroads_48")
                return "Forgotten Crossroads";
            if (scene == "Crossroads_49")
                return "Forgotten Crossroads - The Elevator";
            if (scene == "Crossroads_52")
                return "Forgotten Crossroads - The Legend of Goam";
            if (scene == "Crossroads_ShamanTemple")
                return "Forgotten Crossroads - Ancestral Mound";
            if (scene == "Room_Mender_House")
                return "Forgotten Crossroads - Menderbug's House";
            if (scene == "Room_ruinhouse")
                return "Forgotten Crossroads - Sly Found";
            #endregion

            #region Greenpath
            if (scene == "Fungus1_01")
                return "To Greenpath";
            if (scene == "Fungus1_01b")
                return "Greenpath - Bench";
            if (scene == "Fungus1_02")
                return "Greenpath - Sighting";
            if (scene == "Fungus1_03")
                return "Greenpath - Storerooms"; //// suggest a better name?
            if (scene == "Fungus1_04")
                return "Greenpath - Against Hornet";
            if (scene == "Fungus1_05")
                return "Greenpath";
            if (scene == "Fungus1_06")
                return "Greenpath - No More Going Lost";
            if (scene == "Fungus1_07")
                return "Greenpath";
            if (scene == "Fungus1_08")
                return "Greenpath - Hunter";
            if (scene == "Fungus1_09")
                return "Greenpath";
            if (scene == "Fungus1_10")
                return "Greenpath";
            if (scene == "Fungus1_11")
                return "Greenpath - Foggy Here";
            if (scene == "Fungus1_12")
                return "Greenpath";
            if (scene == "Fungus1_13")
                return "Greenpath - Dreamy Root";
            if (scene == "Fungus1_14")
                return "Greenpath - Thorns";
            if (scene == "Fungus1_15")
                return "Greenpath - Colorful Atmosphere";
            if (scene == "Fungus1_16_alt")
                return "Greenpath - Stag Station";
            if (scene == "Fungus1_17")
                return "Greenpath";
            if (scene == "Fungus1_19")
                return "Greenpath - Bench";
            if (scene == "Fungus1_20_v02")
                return "Greenpath - King of Vengeflys (and Zote)";
            if (scene == "Fungus1_21")
                return "Greenpath";
            if (scene == "Fungus1_22")
                return "Greenpath";
            if (scene == "Fungus1_25")
                return "Greenpath";
            if (scene == "Fungus1_26")
                return "Greenpath - Lake of Unn";
            if (scene == "Fungus1_29")
                return "Greenpath - Massive Moss Charger";
            if (scene == "Fungus1_30")
                return "Greenpath";
            if (scene == "Fungus1_31")
                return "Greenpath - Bench"; //// check?
            if (scene == "Fungus1_32")
                return "Greenpath - Mossy Knights";
            if (scene == "Fungus1_34")
                return "Greenpath";
            if (scene == "Fungus1_35")
                return "Greenpath - Stone Sanctuary";
            if (scene == "Fungus1_36")
                return "Greenpath - Stone Sanctuary";
            if (scene == "Fungus1_37")
                return "Greenpath - Bench";
            if (scene == "Fungus1_Slug")
                return "Greenpath - Unn";
            if (scene == "Room_nailmaster_02")
                return "Greenpath - Sheo the Painter";
            if (scene == "Room_Slug_Shrine")
                return "Greenpath - Lake of Unn";
            #endregion

            #region Fungal Wastes & Queen's Station
            if (scene == "Deepnest_01")
                return "Fungal Wastes";
            if (scene == "Fungus2_01")
                return "Queen's Station";
            if (scene == "Fungus2_02")
                return "Queen's Station - Stag Station";
            if (scene == "Fungus2_03")
                return "Fungal Wastes";
            if (scene == "Fungus2_04")
                return "Fungal Wastes";
            if (scene == "Fungus2_05")
                return "Fungal Wastes - Shrumal Ogres";
            if (scene == "Fungus2_06")
                return "Fungal Wastes";
            if (scene == "Fungus2_07")
                return "Fungal Wastes";
            if (scene == "Fungus2_08")
                return "Fungal Wastes";
            if (scene == "Fungus2_09")
                return "Fungal Wastes - Cloth!";
            if (scene == "Fungus2_10")
                return "Fungal Wastes";
            if (scene == "Fungus2_11")
                return "Fungal Wastes";
            if (scene == "Fungus2_12")
                return "Fungal Wastes - Mantis Corridor!";
            if (scene == "Fungus2_13")
                return "Fungal Wastes - Bench";
            if (scene == "Fungus2_14")
                return "Fungal Wastes - Mantis Village";
            if (scene == "Fungus2_15")
                return "Fungal Wastes - Mantis Village / Against Mantis Lords";
            if (scene == "Fungus2_17")
                return "Fungal Wastes";
            if (scene == "Fungus2_18")
                return "Fungal Wastes - No Longer Lost in Fungis";
            if (scene == "Fungus2_19")
                return "Fungal Wastes";
            if (scene == "Fungus2_20")
                return "Fungal Wastes - Who Said You Can't Focus While Smelly?";
            if (scene == "Fungus2_21")
                return "Fungal Wastes - End of Pilgrim's Way";
            if (scene == "Fungus2_23")
                return "Fungal Wastes - Dashmaster & Bretta";
            if (scene == "Fungus2_26")
                return "Fungal Wastes - Leg Eater's Fragile Shop";
            if (scene == "Fungus2_28")
                return "Fungal Wastes";
            if (scene == "Fungus2_29")
                return "Fungal Wastes - Fungal Core";
            if (scene == "Fungus2_30")
                return "Fungal Wastes - Fungal Core";
            if (scene == "Fungus2_31")
                return "Fungal Wastes - Mantis Village - No Intruders!";
            if (scene == "Fungus2_32" && PlayerData.instance.hasDreamNail)
                return "Fungal Wastes - Against Elder Hu";
            if (scene == "Fungus2_32" && !PlayerData.instance.hasDreamNail)
                return "Fungal Wastes - Elder Hu's Grave";
            if (scene == "Fungus2_33")
                return "Fungal Wastes";
            if (scene == "Fungus2_34")
                return "Queen's Station - Willoh";
            #endregion

            #region Fog Canyon
            if (scene == "Fungus3_01")
                return "Fog Canyon";
            if (scene == "Fungus3_02")
                return "Fog Canyon";
            if (scene == "Fungus3_03")
                return "Fog Canyon - Queen's Gardens Entrance";
            if (scene == "Fungus3_24")
                return "Fog Canyon";
            if (scene == "Fungus3_25")
                return "Fog Canyon - No Longer Lost in Fogs";
            if (scene == "Fungus3_25b")
                return "Fog Canyon - Close Map";
            if (scene == "Fungus3_26")
                return "Fog Canyon";
            if (scene == "Fungus3_27")
                return "Fog Canyon";
            if (scene == "Fungus3_28")
                return "Fog Canyon";
            if (scene == "Fungus3_30")
                return "Fog Canyon - Kinda Taboo";
            if (scene == "Fungus3_35")
                return "Fog Canyon - Millibelle The Banker";
            if (scene == "Fungus3_44")
                return "Fog Canyon - Overgrown Mound Entrance";
            if (scene == "Fungus3_47")
                return "Fog Canyon - Teacher's Archives Entrance";
            if (scene == "Fungus3_archive")
                return "Teacher's Archives - Bench";
            if (scene == "Fungus3_archive_02")
                return "Teacher's Archives";
            if (scene == "Room_Fungus_Shaman")
                return "Overgrown Mound";
            #endregion

            #region Howling Cliffs
            if (scene == "Cliffs_01")
                return "Howling Cliffs";
            if (scene == "Cliffs_02")
                return "Howling Cliffs - The Great Mind";
            if (scene == "Cliffs_03")
                return "Howling Cliffs - Stag Nest";
            if (scene == "Cliffs_04")
                return "Howling Cliffs - Joni's Repose";
            if (scene == "Cliffs_05")
                return "Howling Cliffs - Joni's Repose";
            if (scene == "Cliffs_06")
                return "Howling Cliffs - Troupe's Lantern";
            if (scene == "Fungus1_28")
                return "Howling Cliffs - Protective Shell";
            if (scene == "Room_nailmaster")
                return "Howling Cliffs - Nailmaster Mato";
            #endregion

            #region Crystal Peak
            if (scene == "Mines_01")
                return "Crystal Peak - Entrance";
            if (scene == "Mines_02")
                return "Crystal Peak - Entrance";
            if (scene == "Mines_03")
                return "Crystal Peak";
            if (scene == "Mines_04")
                return "Crystal Peak";
            if (scene == "Mines_05")
                return "Crystal Peak";
            if (scene == "Mines_06")
                return "Crystal Peak - Deep Dash";
            if (scene == "Mines_07")
                return "Crystal Peak";
            if (scene == "Mines_10")
                return "Crystal Peak";
            if (scene == "Mines_11")
                return "Crystal Peak";
            if (scene == "Mines_13")
                return "Crystal Peak - Corridor";
            if (scene == "Mines_16")
                return "Crystal Peak - Cute Disguise";
            if (scene == "Mines_17")
                return "Crystal Peak";
            if (scene == "Mines_18")
                return "Crystal Peak - Guardian... of the Bench";
            if (scene == "Mines_19")
                return "Crystal Peak - Crushers, feat Grub";
            if (scene == "Mines_20")
                return "Crystal Peak";
            if (scene == "Mines_23")
                return "Crystal Peak - Dreamy Root";
            if (scene == "Mines_24")
                return "Crystal Peak - King Grub";
            if (scene == "Mines_25")
                return "Crystal Peak";
            if (scene == "Mines_28")
                return "Crystal Peak";
            if (scene == "Mines_29")
                return "Crystal Peak - Bench";
            if (scene == "Mines_30")
                return "Crystal Peak - Not Lost in Crystals Anymore";
            if (scene == "Mines_31")
                return "Crystal Peak";
            if (scene == "Mines_32")
                return "Crystal Peak - Enraged Guardian";
            if (scene == "Mines_33")
                return "Crystal Peak - Entrance";
            if (scene == "Mines_34")
                return "Crystal Peak - Hallownest's Crown";
            if (scene == "Mines_35")
                return "Crystal Mound";
            if (scene == "Mines_36")
                return "Crystal Peak - Deep Focus";
            if (scene == "Mines_37")
                return "Crystal Peak";
            #endregion

            #region Ancient Basin
            if (scene == "Abyss_02")
                return "Ancient Basin";
            if (scene == "Abyss_03")
                return "Ancient Basin - Tram Station";
            if (scene == "Room_Tram")
                return "Inside Tram (To Dn/AB/K'sE)";
            if (scene == "Abyss_04")
                return "Ancient Basin - Fountain";
            if (scene == "Abyss_05")
                return "Ancient Basin - Palace Grounds";
            if (scene == "Abyss_17")
                return "Ancient Basin - Yet Again, Cloth";
            if (scene == "Abyss_18")
                return "Ancient Basin - Smells like Danger, and Infection";
            if (scene == "Abyss_19")
                return "Ancient Basin - Grubby";
            if (scene == "Abyss_20")
                return "Ancient Basin";
            if (scene == "Abyss_21")
                return "Ancient Basin - Monarch Wings";
            if (scene == "Abyss_22")
                return "Ancient Basin - Hidden (Stag) Station";

            #region The Abyss
            if (scene == "Abyss_06_Core")
                return "The Abyss";
            if (scene == "Abyss_08")
                return "The Abyss - Lifeblood Core";
            if (scene == "Abyss_09")
                return "The Abyss - Darkhouse";
            if (scene == "Abyss_10")
                return "The Abyss - Ghostly Dash";
            if (scene == "Abyss_12")
                return "The Abyss - Ancient Screams";
            if (scene == "Abyss_15")
                return "The Abyss - Birthplace";
            if (scene == "Abyss_16")
                return "The Abyss";
            if (scene == "Abyss_Lighthouse_room")
                return "The Abyss - Lighthouse";
            #endregion
            #endregion

            #region Resting Grounds
            if (scene == "Crossroads_46b")
                return "Resting Grounds - Tram Station";
            if (scene == "Crossroads_50")
                return "Resting Grounds - Blue Lake";
            if (scene == "RestingGrounds_02")
                return "Resting Grounds - Punishment";
            if (scene == "RestingGrounds_04")
                return "Resting Grounds - Dreamers";
            if (scene == "RestingGrounds_05")
                return "Resting Grounds - Whispering Grounds";
            if (scene == "RestingGrounds_06")
                return "Resting Grounds - Corridor";
            if (scene == "RestingGrounds_07")
                return "Resting Grounds - Seer";
            if (scene == "RestingGrounds_08")
                return "Resting Grounds - Spirit's Glade";
            if (scene == "RestingGrounds_09")
                return "Resting Grounds - Stag Station";
            if (scene == "RestingGrounds_10")
                return "Resting Grounds - The Crypts";
            if (scene == "RestingGrounds_12")
                return "Resting Grounds";
            if (scene == "RestingGrounds_17")
                return "Resting Grounds - Dreamshield";
            if (scene == "Room_Mansion")
                return "Resting Grounds - Grey Mourner";
            if (scene == "Ruins2_10")
                return "Resting Grounds - Elevator To City of Tears";
            if (scene == "Crossroads_49b")
                return "Resting Grounds";
            #endregion

            #region Kingdom's Edge
            if (scene == "Abyss_03_c")
                return "Kingdom's Edge - Tram Station";
            if (scene == "Deepnest_East_01")
                return "Kingdom's Edge - Smells like Honey";
            if (scene == "Deepnest_East_02")
                return "Kingdom's Edge - Hive-y";
            if (scene == "Deepnest_East_03")
                return "Kingdom's Edge - Entrance";
            if (scene == "Deepnest_East_04")
                return "Kingdom's Edge - Lotsa Bardoons";
            if (scene == "Deepnest_East_06")
                return "Kingdom's Edge - Hoppers and Aspids";
            if (scene == "Deepnest_East_07")
                return "Kingdom's Edge - Whispering Tree";
            if (scene == "Deepnest_East_08")
                return "Kingdom's Edge";
            if (scene == "Deepnest_East_09")
                return "Kingdom's Edge";
            if (scene == "Deepnest_East_10")
                return "Kingdom's Edge - Markoth";
            if (scene == "Deepnest_East_11")
                return "Kingdom's Edge - More Aspids";
            if (scene == "Deepnest_East_12")
                return "Kingdom's Edge - Hornet Sighting";
            if (scene == "Deepnest_East_13")
                return "Kingdom's Edge - Camp Bench";
            if (scene == "Deepnest_East_14")
                return "Kingdom's Edge";
            if (scene == "Deepnest_East_14b")
                return "Kingdom's Edge - Quick! Slash! ...Charm.";
            if (scene == "Deepnest_East_15")
                return "Kingdom's Edge - Yet Again, Lifeblood";
            if (scene == "Deepnest_East_16")
                return "Kingdom's Edge - Oro's Scarecrow";
            if (scene == "Deepnest_East_17")
                return "Kingdom's Edge - Geo Deposit";
            if (scene == "Deepnest_East_18")
                return "Kingdom's Edge";
            if (scene == "Deepnest_East_Hornet")
                return "Kingdom's Edge - Against Hornet";
            #region Colosseum of Fools
            if (scene == "GG_Lurker")
                return "Kingdom's Edge - Pale Lurker";
            if (scene == "Room_Colosseum_01")
                return "Colosseum of Fools";
            if (scene == "Room_Colosseum_02")
                return "Colosseum of Fools - Bench";
            if (scene == "Room_Colosseum_Bronze")
                return "Colosseum of Fools - Trial of the Warrior";
            if (scene == "Room_Colosseum_Silver")
                return "Colosseum of Fools - Trial of the Conqueror";
            if (scene == "Room_Colosseum_Gold")
                return "Colosseum of Fools - Trial of the Fool";
            if (scene == "Room_Colosseum_Spectate")
                return "Colosseum of Fools - Spectate Zone";
            #endregion

            if (scene == "Room_nailmaster_03")
                return "Kingdom's Edge - Nailmaster Oro";
            if (scene == "Room_Wyrm")
                return "Kingdom's Edge - Cast-Off Shell";

            #region The Hive
            if (scene == "Hive_01")
                return "The Hive - Entrance";
            if (scene == "Hive_02")
                return "The Hive - Whispering Honey";
            if (scene == "Hive_03_c")
                return "The Hive";
            if (scene == "Hive_03")
                return "The Hive";
            if (scene == "Hive_04")
                return "The Hive";
            if (scene == "Hive_05")
                return "The Hive - Against The Hive Knight";
            #endregion
            #endregion

            #region City of Tears
            if (scene == "Abyss_01")
                return "City of Tears - Fallen Elevator";
            if (scene == "Room_nailsmith")
                return "City of Tears - Nailsmith";
            if (scene == "Ruins_Bathhouse")
                return "City of Tears - Pleasure House";
            if (scene == "Ruins_Elevator")
                return "City of Tears - Pleasure House";
            if (scene == "Ruins_House_01")
                return "City of Tears - Protector of Grub";
            if (scene == "Ruins_House_02")
                return "City of Tears - Smells Like Wealth";
            if (scene == "Ruins_House_03")
                return "City of Tears - Eternal Emilitia";
            if (scene == "Ruins1_01")
                return "City of Tears - Entrance";
            if (scene == "Ruins1_02")
                return "City of Tears - Bench w/ Quirrel";
            if (scene == "Ruins1_03")
                return "City of Tears";
            if (scene == "Ruins1_04")
                return "City of Tears - Nail Hammered";
            if (scene == "Ruins1_05")
                return "City of Tears";
            if (scene == "Ruins1_05b")
                return "City of Tears - Relic Seeker Lemm";
            if (scene == "Ruins1_05c")
                return "City of Tears";
            if (scene == "Ruins1_06")
                return "City of Tears";
            if (scene == "Ruins1_09")
                return "City of Tears - Soul Twister Arena";
            if (scene == "Ruins1_17")
                return "City of Tears - Irritating Root";
            if (scene == "Ruins1_18")
                return "City of Tears";
            if (scene == "Ruins1_23")
                return "City of Tears - Soul Sanctum - Entrance";
            if (scene == "Ruins1_24")
                return "City of Tears - Against Soul Master";
            if (scene == "Ruins1_25")
                return "City of Tears - Soul Sanctum";
            if (scene == "Ruins1_27")
                return "City of Tears - The Hollow Knight";
            if (scene == "Ruins1_28")
                return "City of Tears - Storerooms";
            if (scene == "Ruins1_29")
                return "City of Tears - Storerooms Stag Station";
            if (scene == "Ruins1_30")
                return "City of Tears - Soul Sanctum";
            if (scene == "Ruins1_31")
                return "City of Tears - Breaktime With a Mapper";
            if (scene == "Ruins1_32")
                return "City of Tears - Soul Master";
            if (scene == "Ruins2_01")
                return "City of Tears - Watcher's Spire";
            if (scene == "Ruins2_01_b")
                return "City of Tears - Watcher's Spire";
            if (scene == "Ruins2_03")
                return "City of Tears - Against Watcher Knights";
            if (scene == "Ruins2_03b")
                return "City of Tears - Watcher's Spire";
            if (scene == "Ruins2_04")
                return "City of Tears - King's Station"; //// check please
            if (scene == "Ruins2_05")
                return "City of Tears - Above King's Station";
            if (scene == "Ruins2_06")
                return "City of Tears - King's Station";
            if (scene == "Ruins2_07")
                return "City of Tears - King's Station";
            if (scene == "Ruins2_08")
                return "City of Tears - Stag Station (inside K'sS)";
            if (scene == "Ruins2_09")
                return "City of Tears - King's Station";
            if (scene == "Ruins2_10b")
                return "City of Tears - Elevator to Resting Grounds"; //// check please
            if (scene == "Ruins2_11")
                return "City of Tears - The Collector";
            if (scene == "Ruins2_11_b")
                return "City of Tears - Tower of Love";
            if (scene == "Ruins2_Watcher_Room")
                return "City of Tears - Lurien the Watcher";

            #endregion

            #region Royal Waterways
            if (scene == "GG_Pipeway")
                return "Royal Waterways - Flukemungas";
            if (scene == "GG_Waterways")
                return "Royal Waterways - Junk Pit";
            if (scene == "Room_GG_Shortcut")
                return "Royal Waterways - Fluke Hermit";
            if (scene == "Waterways_01")
                return "Royal Waterways - Entrance";
            if (scene == "Waterways_02")
                return "Royal Waterways - Bench";
            if (scene == "Waterways_03")
                return "Royal Waterways - Tuk's Vendor";
            if (scene == "Waterways_04")
                return "Royal Waterways";
            if (scene == "Waterways_04b")
                return "Royal Waterways";
            if (scene == "Waterways_05")
                return "Royal Waterways - Against Dung Defender";
            if (scene == "Waterways_06")
                return "Royal Waterways";
            if (scene == "Waterways_07")
                return "Royal Waterways";
            if (scene == "Waterways_08")
                return "Royal Waterways";
            if (scene == "Waterways_09")
                return "Royal Waterways - Thank You, Kind Mapper!";
            if (scene == "Waterways_12")
                return "Royal Waterways - Against Flukemarm";
            if (scene == "Waterways_13")
                return "Royal Waterways - Isma's Grove";
            if (scene == "Waterways_14")
                return "Royal Waterways";
            if (scene == "Waterways_15")
                return "Royal Waterways - Dung Defender's Cave";
            #endregion

            #region Deepnest
            if (scene == "Abyss_03_b")
                return "Deepnest - Tram Station";
            if (scene == "Deepnest_01b")
                return "Deepnest";
            if (scene == "Deepnest_02")
                return "Deepnest";
            if (scene == "Deepnest_03")
                return "Deepnest - Went From 0 to 100";
            if (scene == "Deepnest_09")
                return "Deepnest - Distant Stag Station";
            if (scene == "Deepnest_10")
                return "Deepnest - Distant Village";
            if (scene == "Deepnest_14")
                return "Deepnest - Failed Tramway - Bench";
            if (scene == "Deepnest_16")
                return "Deepnest";
            if (scene == "Deepnest_17")
                return "Deepnest";
            if (scene == "Deepnest_26")
                return "Deepnest - Failed Tramway";
            if (scene == "Deepnest_26b")
                return "Deepnest - Failed Tramway - Successful Tram Pass";
            if (scene == "Deepnest_30")
                return "Deepnest - Hot Spring (finally)";
            if (scene == "Deepnest_31")
                return "Deepnest";
            if (scene == "Deepnest_32")
                return "Deepnest - Against Nosk";
            if (scene == "Deepnest_33")
                return "Deepnest - Zote the Mighty";
            if (scene == "Deepnest_34")
                return "Deepnest - What a Beast";
            if (scene == "Deepnest_35")
                return "Deepnest";
            if (scene == "Deepnest_36")
                return "Deepnest - Which One Of Us Is Real?";
            if (scene == "Deepnest_37")
                return "Deepnest - Way to the Tram Station";
            if (scene == "Deepnest_38")
                return "Deepnest";
            if (scene == "Deepnest_39")
                return "Deepnest - Distant Root";
            if (scene == "Deepnest_40")
                return "Deepnest - Against Galien";
            if (scene == "Deepnest_41")
                return "Deepnest - Midwife";
            if (scene == "Deepnest_42")
                return "Deepnest";
            if (scene == "Deepnest_44")
                return "Deepnest - Sharp Shadow";
            if (scene == "Deepnest_45_v02")
                return "Deepnest - Weaver's Den";
            if (scene == "Deepnest_Spider_Town")
                return "Deepnest - Beast's Den";
            if (scene == "Fungus2_25")
                return "Deepnest";
            if (scene == "Room_Mask_Maker")
                return "Deepnest - Mask Maker";
            if (scene == "Room_spider_small")
                return "Deepnest - Distant Village";
            if (scene == "Deepnest_43")
                return "Deepnest";
            #endregion

            #region Queen's Gardens
            if (scene == "Fungus1_24")
                return "Queen's Gardens";
            if (scene == "Fungus3_04")
                return "Queen's Gardens";
            if (scene == "Fungus3_05")
                return "Queen's Gardens - Petra Arena";
            if (scene == "Fungus3_08")
                return "Queen's Gardens";
            if (scene == "Fungus3_10")
                return "Queen's Gardens - Main Arena";
            if (scene == "Fungus1_11")
                return "Queen's Gardens - Whispering Root";
            if (scene == "Fungus1_13")
                return "Queen's Gardens";
            if (scene == "Fungus1_21")
                return "Queen's Gardens";
            if (scene == "Fungus1_22")
                return "Queen's Gardens";
            if (scene == "Fungus1_23")
                return "Queen's Gardens - Against Traitor Lord";
            if (scene == "Fungus1_34")
                return "Queen's Gardens - Entrance";
            if (scene == "Fungus1_39")
                return "Queen's Gardens - Moss Prophet";
            if (scene == "Fungus1_49")
                return "Queen's Gardens - Traitor Lord's Child's Grave";
            if (scene == "Fungus1_40")
                return "Queen's Gardens - Stag Station";
            if (scene == "Fungus1_48")
                return "Queen's Gardens - White Rock";
            if (scene == "Fungus1_50")
                return "Queen's Gardens - Luxury Bench";
            if (scene == "Room_Queen")
                return "Queen's Gardens - White Lady";
            if (scene == "Fungus1_24")
                return "Queen's Gardens";
            #endregion

            #region White Palace
            if (scene == "White_Palace_01")
                return "White Palace - Entrance";
            if (scene == "White_Palace_02")
                return "White Palace - First Kingsmould Encounter";
            if (scene == "White_Palace_03_hub")
                return "White Palace - Bench";
            if (scene == "White_Palace_04")
                return "White Palace - To the Left of Bench";
            if (scene == "White_Palace_05")
                return "White Palace - Too Many Saws";
            if (scene == "White_Palace_06")
                return "White Palace";
            if (scene == "White_Palace_07")
                return "White Palace";
            if (scene == "White_Palace_08")
                return "White Palace - Workshop";
            if (scene == "White_Palace_09")
                return "White Palace - The Throne";
            if (scene == "White_Palace_11")
                return "White Palace - Outside";
            if (scene == "White_Palace_12")
                return "White Palace";
            if (scene == "White_Palace_13")
                return "White Palace";
            if (scene == "White_Palace_14")
                return "White Palace";
            if (scene == "White_Palace_15")
                return "White Palace";
            if (scene == "White_Palace_16")
                return "White Palace";
            #region Path of Pain
            if (scene == "White_Palace_17")
                return "White Palace - Path of Pain Lever";
            if (scene == "White_Palace_18")
                return "White Palace - Path of Pain - Entrance";
            if (scene == "White_Palace_19")
                return "White Palace - Path of Pain - Second Room";
            if (scene == "White_Palace_20")
                return "White Palace - Path of Pain - Final Room";
            #endregion
            #endregion

            #region Final Boss
            if (scene == "Dream_Final_Boss")
                return "Against The Radiance";
            if (scene == "Room_Final_Boss_Atrium")
                return "Black Egg - Bench";
            if (scene == "Room_Final_Boss_Core")
                return "Against The Hollow Knight";
            #endregion

            #region Grimm Troupe DLC
            if (scene == "Grimm_Divine")
                return "Dirtmouth - Divine's Tent";
            if (scene == "Grimm_Main_Tent")
                return "Dirtmouth - Grimm's Tent";
            if (scene == "Grimm_Nightmare")
                return "Dirtmouth - Against Nightmare King Grimm";
            #endregion

            #region Dreams
            if (scene == "Dream_01_False_Knight")
                return "Forgotten Crossroads - Against Failed Champion";
            if (scene == "Dream_02_Mage_Lord")
                return "City of Tears - Against Soul Tyrant";
            if (scene == "Dream_03_Infected_Knight")
                return "Ancient Basin - Against Lost Kin";
            if (scene == "Dream_04_Infected_Knight")
                return "Royal Waterways - Against White Defender";
            if (scene == "Dream_Abyss")
                return "The Abyss - No mind to think. No voice to cry suffering.";
            if (scene == "Dream_Backer_Shrine")
                return "Resting Grounds - Shrine of Believers";
            if (scene == "Dream_Guardian_Hegemol")
                return "Deepnest - Herrah the Beast";
            if (scene == "Dream_Guardian_Lurien")
                return "City of Tears - Lurien the Watcher";
            if (scene == "Dream_Guardian_Monomon")
                return "Teacher's Archive - Monomon the Teacher";


            if (scene == "Dream_Mighty_Zote")
                return "Dirtmouth - Against Grey Prince Zote";
            if (scene == "Dream_Nailcollection")
                return "Resting Grounds - Forgotten Dream";
            if (scene == "Dream_Room_Believer_Shrine")
                return "Resting Grounds - Inside Shrine of Believers";

            #region Godhome
            if (scene == "GG_Atrium")
                return "Godhome";
            if (scene == "GG_Atrium_Roof")
                return "Godhome - Pantheon of Hallownest";
            if (scene == "GG_Mighty_Zote")
                return "Godhome - The Eternal Ordeal";
            if (scene == "GG_Spa")
                return "Godhome - Pantheon SPA";
            if (scene == "GG_Unlock_Wastes")
                return "Godhome - Godtuner";
            if (scene == "GG_Workshop")
                return "Godhome - Hall of Gods";
            if (scene == "GG_Engine")
                return "Godhome - A Break With Godseeker";
            if (scene == "GG_Boss_Door_Entrance")
                return "Godhome - Entering Pantheon";
            if (scene == "GG_Engine_Root")
                return "Godhome - White Lady Sighting";
            if (scene == "GG_Unn")
                return "Godhome - Unn Sighting";
            if (scene == "GG_Wyrm")
                return "Godhome - Pale King Sighting";
            if (scene == "GG_End_Sequence")
                return "Godhome - Pantheon Ending";


            #region GG_Bosses

            if (scene == "GG_Gruz_Mother_V")
                return "Godhome - Against Gruz Mother";
            if (scene == "GG_Gruz_Mother")
                return "Godhome - Against Gruz Mother";
            if (scene == "GG_False_Knight")
                return "Godhome - Against the False Knight";
            if (scene == "GG_Mega_Moss_Charger")
                return "Godhome - Against Massive Moss Charger";
            if (scene == "GG_Hornet_1")
                return "Godhome - Against Protector Hornet";
            if (scene == "GG_Ghost_Gorb_V")
                return "Godhome - Against Gorb";
            if (scene == "GG_Ghost_Gorb")
                return "Godhome - Against Gorb";
            if (scene == "GG_Dung_Defender")
                return "Godhome - Against Dung Defender";
            if (scene == "GG_Mage_Knight_V")
                return "Godhome - Against Soul Tyrant";
            if (scene == "GG_Mage_Knight")
                return "Godhome - Against Soul Tyrant";
            if (scene == "GG_Brooding_Mawlek_V")
                return "Godhome - Against the Brooding Mawlek";
            if (scene == "GG_Brooding_Mawlek")
                return "Godhome - Against the Brooding Mawlek";
            if (scene == "GG_Ghost_Xero_V")
                return "Godhome - Against Xero";
            if (scene == "GG_Ghost_Xero")
                return "Godhome - Against Xero";
            if (scene == "GG_Crystal_Guardian")
                return "Godhome - Against Crystal Guardian";
            if (scene == "GG_Ghost_Marmu_V")
                return "Godhome - Against Marmu";
            if (scene == "GG_Ghost_Marmu")
                return "Godhome - Against Marmu";
            if (scene == "GG_Flukemarm")
                return "Godhome - Against Flukemarm";
            if (scene == "GG_Broken_Vessel")
                return "Godhome - Against the Broken Vessel";
            if (scene == "GG_Ghost_Galien")
                return "Godhome - Against Galien";
            if (scene == "GG_Painter")
                return "Godhome - Against Sheo the Painter";
            if (scene == "GG_Hive_Knight")
                return "Godhome - Against the Hive Knight";
            if (scene == "GG_Ghost_Hu")
                return "Godhome - Against Elder Hu";
            if (scene == "GG_Collector_V")
                return "Godhome - Against The Collector";
            if (scene == "GG_Collector")
                return "Godhome - Against The Collector";
            if (scene == "GG_Grimm")
                return "Godhome - Against Grimm Troupe Master";
            if (scene == "GG_Uumuu_V")
                return "Godhome - Against Uumuu";
            if (scene == "GG_Uumuu")
                return "Godhome - Against Uumuu";
            if (scene == "GG_Nosk_Hornet")
                return "Godhome - Against Flying Nosk";
            if (scene == "GG_Sly")
                return "Godhome - Against Great Nailsaga Sly"; //// check?
            if (scene == "GG_Hornet_2")
                return "Godhome - Against Sentinel Hornet";
            if (scene == "GG_Crystal_Guardian_2")
                return "Godhome - Against Enraged Guardian";
            if (scene == "GG_Lost_Kin")
                return "Godhome - Against Lost Kin";
            if (scene == "GG_Ghost_No_Eyes_V")
                return "Godhome - Against No Eyes";
            if (scene == "GG_Ghost_No_Eyes")
                return "Godhome - Against No Eyes";
            if (scene == "GG_Traitor_Lord")
                return "Godhome - Against the Traitor Lord";
            if (scene == "GG_White_Defender")
                return "Godhome - Against the White Defender";
            if (scene == "GG_Ghost_Markoth_V")
                return "Godhome - Against Markoth";
            if (scene == "GG_Ghost_Markoth")
                return "Godhome - Against Markoth";
            if (scene == "GG_Grey_Prince_Zote")
                return "Godhome - Against Grey Prince Zote";
            if (scene == "GG_Failed_Champion")
                return "Godhome - Against the Failed Champion";
            if (scene == "GG_Radiance")
                return "Godhome - Against Absolute Radiance";
            if (scene == "GG_Hollow_Knight")
                return "Godhome - Against the Pure Vessel";
            if (scene == "GG_Grimm_Nightmare")
                return "Godhome - Against Nightmare King Grimm";
            if (scene == "GG_Vengefly_V")
                return "Godhome - Against the Vengefly King";
            if (scene == "GG_Vengefly")
                return "Godhome - Against the Vengefly King";
            if (scene == "GG_Nailmasters")
                return "Godhome - Against Nailmaster Oro & Mato";
            if (scene == "GG_Soul_Master")
                return "Godhome - Against Soul Master";
            if (scene == "GG_Oblobbles")
                return "Godhome - Against Oblobbles";
            if (scene == "GG_Mantis_Lords_V")
                return "Godhome - Against the Mantis Lords";
            if (scene == "GG_Mantis_Lords")
                return "Godhome - Against the Mantis Lords";
            if (scene == "GG_God_Tamer")
                return "Godhome - Against the God Tamer";
            if (scene == "GG_Watcher_Knights")
                return "Godhome - Against Watcher Knights";
            if (scene == "GG_Soul_Tyrant")
                return "Godhome - Against Soul Tyrant";
            if (scene == "GG_Nosk")
                return "Godhome - Against Nosk";

            #endregion
            #endregion
            #endregion

            #region Modded Content
            if (scene == "SF_ToT_ToT_01")
                return "Test of Teamwork";
            if (scene == "SF_ToT_ToT_02")
                return "Test of Teamwork";
            if (scene == "SF_ToT_ToT_03")
                return "Test of Teamwork";
            if (scene == "SF_ToT_ToT_Endless")
                return "Test of Teamwork";
            if (scene == "SF_ToT_ToT_Dropdown")
                return "Test of Teamwork";

            if (RoomNamesHelper.GetFriendlyName(scene) != scene)
                return RoomNamesHelper.GetFriendlyName(scene);
            #endregion


            else return scene;
        }

        public static Assetz GetSmallAsset(string newName)
        {
            if (newName == "Greenpath - Sheo the Painter")
                return new Assetz { Image = "sheo", Text = "Greenpath" };
            if (newName == "Fog Canyon - Teacher's Archives Entrance")
                return new Assetz { Image = "archives", Text = "Teacher's Archives" };
            if (newName == "Greenpath - Against Hornet")
                return new Assetz { Image = "hornet", Text = "Greenpath" };
            if (newName == "Kingdom's Edge - Against Hornet")
                return new Assetz { Image = "hornet", Text = "Kingdom's Edge" };
            if (newName == "Overgrown Mound")
                return new Assetz { Image = "fog", Text = "Fog Canyon" };
            if (newName == "Crystal Mound")
                return new Assetz { Image = "crystal", Text = "Crystal Peak" };
            if (newName == "Black Egg - Bench")
                return new Assetz { Image = "blackegg", Text = "Forgotten Crossroads" };
            if (newName == "Against The Hollow Knight")
                return new Assetz { Image = "hollowknight", Text = "" };
            if (newName == "Against The Radiance")
                return new Assetz { Image = "radiance", Text = "" };

            if (newName.StartsWith("Dirtmouth"))
                return new Assetz { Image = "dirtmouth", Text = "Dirtmouth" };
            if (newName.StartsWith("King's Pass"))
                return new Assetz { Image = "kingspass", Text = "King's Pass" };
            if (newName.StartsWith("Forgotten Crossroads"))
                return new Assetz { Image = "crossroads", Text = "Forgotten Crossroads" };
            if (newName.StartsWith("Greenpath"))
                return new Assetz { Image = "greenpath", Text = "Greenpath" };
            if (newName.StartsWith("Fungal Wastes"))
                return new Assetz { Image = "wastes", Text = "Fungal Wastes" };
            if (newName.StartsWith("Teacher's Archives"))
                return new Assetz { Image = "archives", Text = "Teacher's Archives" };
            if (newName.StartsWith("Fog Canyon"))
                return new Assetz { Image = "fog", Text = "Fog Canyon" };
            if (newName.StartsWith("Queen's Station"))
                return new Assetz { Image = "wastes", Text = "Queen's Station" };
            if (newName.StartsWith("Ancient Basin"))
                return new Assetz { Image = "basin", Text = "Ancient Basin" };
            if (newName.StartsWith("The Abyss"))
                return new Assetz { Image = "abyss", Text = "The Abyss" };
            if (newName.StartsWith("Resting Grounds"))
                return new Assetz { Image = "grounds", Text = "Resting Grounds" };
            if (newName.StartsWith("City of Tears"))
                return new Assetz { Image = "city", Text = "City of Tears" };
            if (newName.StartsWith("The Hive"))
                return new Assetz { Image = "hive", Text = "The Hive" };
            if (newName.StartsWith("Kingdom's Edge"))
                return new Assetz { Image = "kedge", Text = "Kingdom's Edge" };
            if (newName.StartsWith("Colosseum of Fools"))
                return new Assetz { Image = "fool", Text = "Colosseum of Fools" };
            if (newName.StartsWith("White Palace - Path of Pain"))
                return new Assetz { Image = "pop", Text = "White Palace" };
            if (newName.StartsWith("White Palace"))
                return new Assetz { Image = "whitepalace", Text = "White Palace" };
            if (newName.StartsWith("Royal Waterways"))
                return new Assetz { Image = "waterways", Text = "Royal Waterways" };
            if (newName.StartsWith("Howling Cliffs"))
                return new Assetz { Image = "kingspass", Text = "Howling Cliffs" };
            if (newName.StartsWith("Crystal Peak"))
                return new Assetz { Image = "crystal", Text = "Crystal Peak" };
            if (newName.StartsWith("Deepnest"))
                return new Assetz { Image = "deepnest", Text = "Deepnest" };
            if (newName.StartsWith("Godhome"))
                return new Assetz { Image = "god", Text = "Godhome" };





            if (newName.StartsWith("Test of Teamwork"))
                return new Assetz { Image = "hornet", Text = "Test of Teamwork (Modded Content)" };




            else
                return new Assetz { Image = "", Text = "" };
        }

        /// <summary>
        /// Class for registering scene names for display in Discord RPC status.
        /// </summary>
        public static class RoomNamesHelper
        {
            private static Dictionary<string, string> _scenelist = new Dictionary<string, string>();

            /// <summary>
            /// Registered Custom Scenes list.
            /// <br></br>
            /// See: <see cref="RegisterScene(string, string)"/>
            /// </summary>
            public static Dictionary<string, string> CustomScenes
            {
                get
                {
                    return _scenelist;
                }

                private set
                {
                    _scenelist = value;
                }
            }

            /// <summary>
            /// Registers scene for display in Discord RPC status.
            /// <br></br>
            /// 
            /// 
            /// Often used by <see cref="RoomNames.GetRoomName(string)"/>.
            /// <br />
            /// <br />
            /// <u>If you want to add a custom icon, PLEASE DM me or make an issue on this GitHub project. This class won't be able to help you add custom icons.</u>
            /// </summary>
            /// <param name="scene">Name of the scene you're using.</param>
            /// <param name="name">Friendly name for display in RPC status.</param>
            public static void RegisterScene(string scene, string name)
            {
                _scenelist.Add(scene, name);
            }

            /// <summary>
            /// Gets friendly name for the scene. If none found, return the first parameter used in this method.
            /// </summary>
            /// <param name="scene">Scene name.</param>
            /// <returns>If found, the friendly name. If not, returns <paramref name="scene"/></returns>
            public static string GetFriendlyName(string scene)
            {
                if (!_scenelist.Keys.ToList().Exists(x => x == scene)) return scene;

                return _scenelist[_scenelist.Keys.ToList().Find(x => x == scene)];
            }
        }
    }

    public struct Assetz
    {
        public string Image;
        public string Text;
    }
}
