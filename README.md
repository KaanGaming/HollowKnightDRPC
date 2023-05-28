



# Hollow Knight Discord Rich Presence

---

This mod adds Discord Rich Presence to your profile. Rich Presence is a detailed "Playing" status when you check someone's profile on Discord. It shows up in both mobile and computer devices.

![Example](https://i.ibb.co/421PW5x/resim-2021-12-17-191656.png)
###### Even though the text may be cut off, it can be seen in full by hovering over your mouse on the cut off text, or view the full profile.

This mod was made by __@KaanGaming#7447__ on Discord.
If anything goes wrong, ask in [#modding-help](https://discord.com/channels/283467363729408000/462200562620825600) in the Hollow Knight's Discord server.

Other links that may be useful:

[Original README](https://github.com/KaanGaming/HollowKnightDRPC/blob/main/ModInstallerReadme.txt)

# Installation Guide
Use these if the mod couldn't do the auto-installation of Discord GameSDK.

✔ [Windows Guide](https://kaangaming.github.io/HollowKnightDRPC/guide/Guide.html)

✖ Mac Guide

✖ Linux/UNIX Guide 

### Vague guide on setting up mod for use
(The mod was updated to fix the auto-installation issue for Mac OS X and Linux users. If you do still encounter problems, consult to this guide.)

First, download the Discord GameSDK from [here](https://discord.com/developers/docs/game-sdk/sdk-starter-guide). Open the .zip file, and try to find the `lib` folder. Inside there should be `x86` and `x86_64` folders. Find the `Plugins` folder in your Hollow Knight installation. Your Hollow Knight game files can be found in (Windows: `C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight\`, Mac: `~/Library/Application Support/Steam/steamapps/common/Hollow Knight/hollow_knight.app/`, Linux: `~/.local/share/Steam/steamapps/common/Hollow Knight/`). Copy the `x86` and `x86_64` into `Plugins` folder. If there are already folders with the same names, copy the insides of `x86` from the .zip to there, and the same thing for `x86_64`.


# How to use
**THE MOD ONLY WORKS IF YOU HAVE DISCORD CLIENT OPEN! THE BROWSER VERSION OF DISCORD WON'T WORK AND YOUR RICH PRESENCE WILL NOT WORK.** If you are using this mod on 1.5, you can easily adjust the settings in Settings > Mods and find this mod's settings page. On 1.4.3.2, this option doesn't exist, but you can still change settings by finding the saves location and find this mod's global settings. Despite it being a JSON file, it's very easy to edit. You can use the notepad program to edit values. [The StatsRow may be complex, so I made a page about it so you can edit them to whatever you want without testing each value.](https://github.com/KaanGaming/HollowKnightDRPC/blob/1.5-mapi-version/StatsRowValues.md)

# Development Guide

Steps:
### Project setup
1. Get the Discord GameSDK (found [here](https://discord.com/developers/docs/game-sdk/sdk-starter-guide)) and go inside the `lib` folder, then extract the contents of `x86` and `x86_64` into `HollowKnightDRPC\GameSDK_Libraries` (there are `x86` and `x86_64` folders inside there as well so extract the respective folders into there)
2. Create a symlink folder that leads to the Managed folder inside Hollow Knight's game files. This location can vary depending on what operating system you're running.

### Build the project
When you build the project, the build result gets pasted into the Mods directory in Hollow Knight. To export the mod, the export location is usually located in `E:\Github_Projects\\__Exports\HollowKnightDRPC`. The export folder contains the .ZIP for Scarab to unpack and load into the Mods folder (and to link it to the modlinks), a .DLL file of the mod, and SHA.txt which has the SHA256 hash of the .ZIP (for modlinks).

---

## Previews

![](https://i.ibb.co/0n08pWj/prev1.png)
###### Dirtmouth - Normal save
---
![](https://i.ibb.co/7z2Yr5C/prev2.png)
###### Stag Nest - Normal save
---
![](https://i.ibb.co/9rYZJ3K/prev3.png)
###### Black Egg Temple - Normal save
---
![](https://i.ibb.co/Z6XXTsF/prev4.png)
###### Ancestral Mound - Steel Soul save
---
![](https://i.ibb.co/Zc1FhMG/prev5.png)
###### Godhome | Hall of Gods - Godseeker save
---
![](https://i.ibb.co/6txKTkq/prev6.png)
###### Small Image Tooltip
