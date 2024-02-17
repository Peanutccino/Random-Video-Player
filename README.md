#### Random Video Player

![Logo](https://i.imgur.com/PxbT2cd.png)

Hello everyone,

I've worked on this player for quiet some time and added functionality continuosly. I'm a rookie developer so the structure might be terrible and not all checks are there. I'm looking to improve the code further, but as of right now under constant use on different machines, it workes pretty damn well.

My goal was to create a good looking, fast and efficient way to play random videos out of any directory or even custom made lists I want. I've tried all the big stuff like VLC, MPC etc. but they all make it surprisingly difficult to execute this task.

## Features:
* Playing random videos from a location you define with a simple click
* Create/Save/Load custom lists filled with video files you can define
* Quick and easy navigation
* Hotkeys and Mousecontrols for quick and easy control of the player
* Synchronize with MultiFunPlayer while playing random videos

## Current problems with Microsoft Defender
As it seems, MS Defender does not like something in the code and gives a false positive. So far I could only reproduce this on Win 11; On Win 10 I couldn't.
I submitted a ticket to Microsoft, but until I can resolve this issue (or not) the easiest workaround would be the following:
* Download the file, it will fail
* Start -> Virus & Threat Protection
* 'Protection History'
* Expand the header that say 'Thread quarantined'
* under 'Actions' choose 'restore'


## Prerequisites

The player uses Mpv.Net-lib- which I've modified to make use of the latest 'libmpv-2.dll' instead of the outdated mpv-1.dll. (The project is sadly abandoned)
1. Download 'libmpv-2.dll' from here: https://sourceforge.net/projects/mpv-player-windows/files/libmpv/
   * Use 64-bit version  e.g. mpv-dev-x86_64
3. Create a folder called 'lib' in the projects folder.
4. Extract 'libmpv-2.dll' from the archive and move it to your 'lib' folder or drag it into visual studio directly.
5. In your Solution Explorer, click on 'libmpv-2.dll' and select 'Properties'. Change the value for "Copy to Output Directory" to "Copy Always".

1. Download Mpv.NET-lib- from https://github.com/hudec117/Mpv.NET-lib-
2. Extract it and open 'Mpv.NET.csproj' in visual studio
   * In Mpv.NET\Player\MpvPlayer.cs; find 'possibleLibMpvPaths' and rename 'mpv-1.dll' to 'libmpv-2.dll'
   * It should look like this: "libmpv-2.dll", @"lib\libmpv-2.dll"
   * Under Mpv.NET\API\MpvFunctions.cs; find 'LoadFunction<MpvDetachDestroy>("mpv_detach_destroy");'
   * Rename string to "mpv_destroy"
3. Compile 'Mpv.NET.dll' (You can add it to the RVP project folder)
4. In visual studio with the Random Video Player open, go to project, add dependency, browse for the 'Mpv.NET.dll' and add it
5. Check the the .dll and press ok
6. It should now be added to dependencies within your solution explorer under assemblys. From there you can choose to create a local copy.

## First run
1. On it's first run, every setting will be at default and the application will create a config file next to it's executable called 'RVP-Config.json' where settings will be stored from now on.
2. Click on the cog-wheel icon to setup everything.
3. Typical usage would be something like:
   * Open Player with your default folder, either press play or
   * Open the FileBrowser / ListBrowser to choose which folder to play from / create a list to play from
   * Switch the toggle for 'Folder/List' depending on what you want to play

## Synchronize with MultiFunPlayer(MFP)
1. Download MFP if you don't already have it https://github.com/Yoooi0/MultiFunPlayer
2. In RVP under settings, activate 'Timecode Server'
3. In MFP, activate 'MPC-HC' as a source
4. While RVP is running, press connect on MFP and it starts synchronizing
5. You need to play videos from your folder with scripts ofc.
6. Have Fun!
  
## Hotkeys and stuff
There are multiple hotkeys for ease of use:
* Scroll on the player to move forward/backwards in the video
* Scroll on the volume bar to increase / decrease volume
* Arrowkeys left/right to go back/forward in the playlist
* Mouse buttons 4 and 5 to go back/forward in the playlist
* Right click on the player jumps to the next track
* Double click on the player sets it to an exclusive fullscreen mode (again to revert)
* Spacebar pauses/resumes playback
* Escape closed the player immediately
* Delete will delete the currently player file (depending on your settings)

## Credits:
* hudec117 and their awesome Mpv.Net-lib- which I've modified to use the latest 'libmpv-2.dll' https://github.com/hudec117/Mpv.NET-lib-
* RJCodeAdvanceEN for their amazing modern ui templates https://www.youtube.com/@RJCodeAdvanceEN
* awesome-incs library for simple and easy control implementation https://github.com/awesome-inc/FontAwesome.Sharp
* JamesNK for their amazing library which I've used to serialize permanent settings https://github.com/JamesNK/Newtonsoft.Json
* Yoooi0 for their incredible T-Code synchronizer https://github.com/Yoooi0/MultiFunPlayer
