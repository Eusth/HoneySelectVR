# HoneySelectVR

This is an experimental mod for the trial edition of Honey Select that introduces VR capabilities for both the Vive and the Oculus Rift using OpenVR. It provides both a seated and a standing mode to be usable in any environment.


## Installation

1. Download [the latest release](https://github.com/Eusth/HoneySelectVR/releases) and extract it into your *HoneySelectTrial* directory.
2. Run *HoneySelectTrial_64VR.exe*
3. Enjoy!

**Caution:** SteamVR needs to be installed, set up, and running! Rift users might otherwise experience a weird "monitor" effect.

## Modes & Controls

HoneySelectVR comes in two *modes*:

| Mode        | Description         |
| ----------- | ------------------- |
| Seated      | *Default mode.* This mode lets you play the game with a mouse, keyboard, or gamepad.<br />The controls are essentially the same as in the main game. The screen is presented on a big monitor in front of you. |
| Standing    | As soon as tracked controllers are registered by the game, it switches into *standing mode*, also called *room scale mode*. In this mode, you can freely move around and use your Vive or Touch controllers to stuff. |


### Seated Mode

As stated earlier, the controls are basically the same as in the main game with the exception of a few VR-related shortcuts. You are presented with a screen in front of your that replaces your monitor and can be configured via the settings or via shortcuts (see below).

#### Keyboard Shortcuts

Keys      | Effect
----      | ------
<kbd>Ctrl</kbd>+<kbd>C</kbd>, <kbd>Ctrl</kbd>+<kbd>C</kbd> | Change to *standing mode*.
<kbd>Ctrl</kbd>+<kbd>C</kbd>, <kbd>Ctrl</kbd>+<kbd>V</kbd> | Enable (very experimental) third person camera. [Was used for this video](https://www.youtube.com/watch?v=0klN6gd1ybM).
<kbd>Alt</kbd>+<kbd>S</kbd> | Save settings (IPD, screen position, etc.).
<kbd>Alt</kbd>+<kbd>L</kbd> | Load settings (last saved state).
<kbd>Ctrl</kbd>+<kbd>Alt</kbd>+<kbd>L</kbd> | Reset settings to the initial state.
<kbd>F4</kbd> | Switch GUI projection mode (flat, curved, spherical).
<kbd>F5</kbd> | Toggle camera lock (enabled by default). This prevents the camera to *tilt* because such movements are known to cause cyber sickness.
<kbd>Ctrl</kbd>+<kbd>F5</kbd> | Apply shaders (only for the brave)
<kbd>F12</kbd> | Recenter
<kbd>NumPad +</kbd> <br /> <kbd>NumPad –</kbd> | Move GUI up / down.
<kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>NumPad +</kbd> <br /> <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>NumPad –</kbd> | Move GUI left / right
<kbd>Ctrl</kbd>+<kbd>NumPad +</kbd> <br /> <kbd>Ctrl</kbd>+<kbd>NumPad –</kbd> | Increase / decrease GUI size.
<kbd>Alt</kbd>+<kbd>NumPad +</kbd> <br /> <kbd>Alt</kbd>+<kbd>NumPad –</kbd> | Increase / decrease player scale
<kbd>Shift</kbd>+<kbd>NumPad +</kbd> <br /> <kbd>Shift</kbd>+<kbd>NumPad –</kbd> | Increase / decrease GUI distance

### Standing Mode

The *standing mode* is where things start to get interesting. This mode is pretty much disconnected from the usual game in that it comes with its very own controls -- although you can still use your mouse and your keyboard.

#### Keyboard Shortcuts

Keys      | Effect
----      | ------
<kbd>Ctrl</kbd>+<kbd>C</kbd>, <kbd>Ctrl</kbd>+<kbd>C</kbd> | Change to *s mode*.
<kbd>Ctrl</kbd>+<kbd>C</kbd>, <kbd>Ctrl</kbd>+<kbd>V</kbd> | Enable (very experimental) third person camera. [Was used for this video](https://www.youtube.com/watch?v=0klN6gd1ybM).
<kbd>Alt</kbd>+<kbd>S</kbd> | Save settings (IPD, screen position, etc.).
<kbd>Alt</kbd>+<kbd>L</kbd> | Load settings (last saved state).
<kbd>Ctrl</kbd>+<kbd>Alt</kbd>+<kbd>L</kbd> | Reset settings to the initial state.
<kbd>Ctrl</kbd>+<kbd>F5</kbd> | Apply shaders (only for the brave)
<kbd>Alt</kbd>+<kbd>NumPad +</kbd> <br /> <kbd>Alt</kbd>+<kbd>NumPad –</kbd> | Increase / decrease player scale

## Tools

These tools are mainly meant to be used in *standing mode* but some of them are also available in *seated mode*. By default, your left hand will start with the *menu tool* and your right hand will start with the *warp tool*. In order to change them on either hand, press the *menu button* on your Vive controller. [See here an overview of buttons](https://forums.unrealengine.com/attachment.php?attachmentid=87367&d=1460020388).

**You can get in-game help any time by holding the menu button!**

### Menu Tool (seated / standing)

<img src="https://github.com/Eusth/PlayClubVR/raw/master/Manual/menu_tool.png">

With the *menu tool* you can interact with the user interface of the game. There are, in fact, two ways you can control the mouse: a two-handed way that makes use of a laser pointer, and a one-handed way that lets you use your trackpad like a ... touchpad!

#### Laser pointer

<img src="https://github.com/Eusth/PlayClubVR/raw/master/Manual/laser_pointer.jpg">

To use the laser pointer, simply point the *other controller* at the menu screen. A laser pointer will appear and you can easily interact with the UI. To make a click, press the trigger button.

#### Trackpad

To use the trackpad, slide with your thumb over the trackpad and the mouse cursor will move accordingly. To make a click, press the trackpad.

#### Attaching, Detaching and Resizing the Menu

<img src="https://github.com/Eusth/PlayClubVR/raw/master/Manual/scale.jpg">

It's possible to detach and resize the menu you're holding at any point in the game.

Simply press the grip button to "let go" of the menu screen -- the screen will then stay put where you left it. You can even use other tools and still interact with the screen using the *laser pointer* mechanism.

Furthermore, it's possible to *resize* the screen. In order to do that, point both your controllers at a screen, press the trigger button, and move the controllers apart. It's also possible to move the screen around like this.

Lastly, to take control of the screen again, press the grip button once more.

### Warp Tool (standing)

<img src="https://github.com/Eusth/PlayClubVR/raw/master/Manual/warp_tool.png">

The *warp tool* is only available in room scale mode and allows you to jump around in the scene.

#### Warping

In order to warp, touch the trackpad, choose your position and press. While touching the trackpad you are able to see:

1. Where you will warp to
2. Your play area
3. A HMD that further shows where your head will be

You can also *rotate* your play area while touching the trackpad by drawing circles with your thumb.

<img src="https://github.com/Eusth/PlayClubVR/raw/master/Manual/warp.jpg">

#### Changing Scale and Height

It's also possible to change scale and height with this tool, although it's a bit cumbersome at the moment. To do this, hold the trackpad *pressed* before warping. You can now change your future height by moving the Vive controller up and down and your scale by moving back and forth. Note that you can only change one of those two each time.

By pressing the *grip button* you can reset the scale and height.

## Settings & Tweaks

Settings can be changed in the file *vr_settings.xml*, which is generated the first time you start the game. Use `RenderScale` to tweak the resolution, **not** the internal resolution dialog, as that one will currently only change the resolution of the GUI.

Tag      | Default | Effect | Mode
----     | ------  | ------ | ----
`<Distance>` | 0.3 | Sets the distance between the camera and the GUI at `[0,0,0]`. | Seated
`<Angle>` | 170 | Sets the width of the arc the GUI takes up.  | Seated
`<IPDScale>` | 1 | Sets the scale of the camera. The higher, the more gigantic the player is. | Seated / Standing
`<OffsetY>` | 0 | Sets the vertical offset of the GUI in meters. | Seated
`<Rotation>` | 0 | Sets by how many degrees the GUI is rotated (around the y / up axis) | Seated
`<Rumble>` | True | Sets whether or not rumble is activated. | Seated / Standing
`<RenderScale>` | 1 | Sets the render scale of the renderer. Increase for better quality but less performance, decrease for more performance but poor quality. | Seated / Standing
`<MirrorScreen>` | False | Sets whether or not the view should be mirrored in the game window. | Seated / Standing
`<ApplyShaders>` | False | Sets whether or not post-processing shaders should automatically be applied to the camera. | Seated / Standing

## Building HoneySelectVR

HoneySelectVR depends on the [VRGIN](https://github.com/Eusth/VRGIN) library which is included as a submodule. It is therefore important that when you clone the project, you clone it recursively.

```
git clone --recursive https://github.com/Eusth/HoneySelectVR.git
cd HoneySelectVR
```

After cloning the repo and setting up the submodule, you should be able to compile the project by simply opening the *.sln file and building.

Note that there is a build configuration called "Install" that will extract your Honey Select Trial install directory from the registry and copy the files where they belong. 
