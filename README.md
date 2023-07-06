<!-- ABOUT THE Randomizer -->
## About The Randomizer

A Console Application with an xml user setting where you can choose your difficulty for your Randomizing setting.

There are some rules to follow to avoid Application errors:
* 1- You can only change values of [userSetting.xml] by using [false or true "lowercase" || 0 or 1].
* 2- it's better to completely close the game before using Randomizer.
* 3- Unfortunately every time you want to change some value in the [userSetting.xml] you need a clean Copy of game file.

The xml user settings are:
* 1- Enable_HangarPatch
* 2- Explode_OnKill
* 3- Randomize_HealthValue
* 4- Randomize_UnitModel
* 5- Randomize_BossModel
* 6- Randomize_BackPack
* 7- Randomize_Weapons
* 8- Randomize_EquipmentsLvl
* 9- Randomize_BodyPart
* 10- Randomize_PilotLvl
* 11- Randomize_Skills
* 12- Randomize_Items



### [Enable_HangarPatch]

This setting will enable all Wanzer parts at lvl 1.
There is a file comes with the Randomizer app, Named [004B7670 shopFM5a], This file is required

Credit to [FAN TRANSLATION PROJECT] for their Awesome translation.

### [Explode_OnKill]

This setting will make Wanzer expload on kill, there are 2 type of explotion, low and high.
Low explosion deal 650 damage in 2 square.
High explosion deal 2700 damage in 2 square.

The setting will randomizer three values, [None, Low and High].

### [Randomize_HealthValue]

This setting will randomize Health value of parts, from 1% up to 100%, where 1% is the lowest health value.


### [Randomize_UnitModel]

This setting will randomize Wanzer model in the current stage that you're in.

Why ?
That's because of the limitation of the game files, some models required a large amount of datas array in the file,
and some stages are very limited with some datas.

### [Randomize_BossModel]

Exactly same as randomizing models.

### [Randomize_BackPack]

This setting will randomize Wanzer backpack, [Turbo, item, repair, EMP].
And even boss unit can have as well.

### [Randomize_Weapons]

This setting will randomize Wanzer weapons.
There is an issue in the weapon textures.
For example: if the Wanzer have sniper weapon, and the randomizer set the weapon at shotgun weapon, 
the new weapon will work fine but the model of the weapon will be same as old model which is sniper.

Why ?
Same as unit models, there is a limitation of files datas.

### [Randomize_EquipmentsLvl]

This setting will randomize weapon and Wanzer parts along with backpack levels , from 1 to 12.
Be aware, this may be very difficult in early playthrough.

### [Randomize_BodyPart]

This Will randomize Wanzer parts stats, Such as Defence health value avoiding and much more, but can't randomize the textures.

Why ?
Because of the limitation on files data.

### [Randomize_PilotLvl]

This will randomize pilot level from 1 to 50 , the more pilot level is the more can resist EMP and have higher avoiding chance.

### [Randomize_Skills]

This will randomize pilot skills up to 16 skill based on his current skill level.
Luckily the game will adjust the skills based on pilot type.

### [Randomize_Items]

This will randomize pilot items if the backpack type of item.


<!-- Downloading -->
## How to download the Randomizer

Click on releases page in github or click [Here](https://github.com/KhaleedSA/FM5RandomizerApp/releases/tag/v1.0.0-FM5), then go down to assets and choose one of two Target runtime [win-x64 or win-x86 -> x32 bit] extract the content and run the randomizer.
The game should be in the same [FM5RandomizerApp] path.

### Requirements

App is required .net6 sdk, you can download it from official Microsoft Website.
[official Microsoft](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

And [004B7670 shopFM5a] file, this file is the hangar patch, without it the patch won't work.
The file is already with the randomizer, if somehow you needed for the file, you can download it separately, in the release page assets section.
[004B7670 shopFM5a](https://github.com/KhaleedSA/FM5RandomizerApp/releases/tag/v1.0.0-FM5).

<!-- Installation -->
### Installation

Really simple, exctract zip content and run the app, two file are required the [004B7670 shopFM5a] and the [Game iso]
At the first run, the app will extract a file named [RandomizerSetting] this xml has The settings you need for adjust the randomizing that you want.

<!-- ROADMAP -->
## Roadmap

- [x] Enable_HangarPatch
- [x] Explode_OnKill
- [] PilotLvl_SamePlayer
- [] Unit_CanUseBossWeapon
- [] Randomize_StartUpPilot
- [x] Randomize_HealthValue
- [] Randomize_UnitCoordinate
- [] Randomize_HealthDisplay
- [] Randomize_MapUnitModel
- [x] Randomize_UnitModel
- [x] Randomize_BossModel
- [x] Randomize_BackPack
- [x] Randomize_Weapons
- [x] Randomize_EquipmentsLvl
- [x] Randomize_BodyPart
- [x] Randomize_PilotLvl
- [x] Randomize_Skills
- [x] Randomize_Items


<!-- Credit -->
## Credit

Credit to [FAN TRANSLATION PROJECT] for the translation patch.

<!-- CONTACT -->
## Contact

[@khaleed681](https://twitter.com/khaleed681)

[KhaleedSA](https://github.com/KhaleedSA)
