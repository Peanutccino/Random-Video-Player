#### Random Video Player - RVP

![Logo](https://i.imgur.com/L1EOUnJ.png)

Hello everyone,

RVP is a clean media player based on the powerful MPV. As the title suggests, it's built to play random videos first and foremost, in an easy-to-use and intuitive way.

My goal was to create a good-looking, fast, and efficient way to play random videos from any directory or even custom-made lists. I've tried all the big players like VLC, MPC, etc., but they all make it surprisingly difficult to execute this task.

RVP doesn't stop there, though, as it's got quite the feature set:

## Features:
* Start playing random videos from any location you define or simply your whole collection
* Create/Edit/Save/Load custom lists with the videos you choose
* Open your videos with RVP to start playing right away
* Drag&Drop videos directly on RVP to play from their directory
* Quick and easy navigation
* Amazing and customizable UI
* Customizable Hotkeys and Mousecontrols for quick and easy control of the player
* Synchronize with MultiFunPlayer while playing random videos, now with visualizer

## Prerequisites (When compiling yourself)

The player uses Mpv.Net-lib- which I've modified to make use of the latest 'libmpv-2.dll' instead of the outdated mpv-1.dll. (The project is sadly abandoned)
1. Download 'libmpv-2.dll' from here: https://sourceforge.net/projects/mpv-player-windows/files/libmpv/
   * Use 64-bit version  e.g. mpv-dev-x86_64
3. Create a folder called 'lib' in the projects folder.
4. Extract 'libmpv-2.dll' from the archive and move it to your 'lib' folder or drag it into visual studio directly.
5. In your Solution Explorer, click on 'libmpv-2.dll' and select 'Properties'. Change the value for "Copy to Output Directory" to "Copy Always".

1. Download Mpv.NET-lib- from https://github.com/hudec117/Mpv.NET-lib- or simply use mine from a release package and include it and skip those steps
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
4. You can also open videos with RVP right away, simply choose 'open with' and search for RandomVideoPlayer.exe (where you saved it)

## Synchronize with MultiFunPlayer(MFP)
1. Download MFP if you don't already have it https://github.com/Yoooi0/MultiFunPlayer
2. In RVP under settings, activate 'Timecode Server'
3. In MFP, activate 'MPC-HC' as a source
4. While RVP is running, press connect on MFP and it starts synchronizing
5. You need to play videos from your folder with scripts ofc.
6. Have Fun!
  
## Hotkeys
There are multiple shortcuts for ease of use:
* Scroll on the player to move forward/backwards in the video
* Scroll on the volume bar to increase / decrease volume
* Double click on the player sets it to an exclusive fullscreen mode (again to revert)

Most of the hotkeys can be changed in the settings:

![Logo](https://i.imgur.com/9RxCiJS.png)


## Outro:
I've worked on this player for quiet some time and added functionality continuosly. I'm a rookie developer so the structure might be terrible and not all checks are there. Anyways I'm constantly trying to improve it and add functionality based on user feedback and my own ideas. So far, RVP works pretty good!

## Credits:
* hudec117 and their awesome Mpv.Net-lib- which I've modified to use the latest 'libmpv-2.dll' https://github.com/hudec117/Mpv.NET-lib-
* RJCodeAdvanceEN for their amazing modern ui templates https://www.youtube.com/@RJCodeAdvanceEN
* awesome-incs library for simple and easy control implementation https://github.com/awesome-inc/FontAwesome.Sharp
* JamesNK for their amazing library which I've used to serialize permanent settings https://github.com/JamesNK/Newtonsoft.Json
* Yoooi0 for their incredible T-Code synchronizer https://github.com/Yoooi0/MultiFunPlayer
