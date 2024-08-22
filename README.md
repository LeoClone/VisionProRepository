# VisionProRepository

Initial Steps
1. Open the project "visionOSTemplate-1.1.6" from Unity Hub.
2. Once opened, go to Build Settings and switch platform to VisionOS

Main Scenes
1. __Scene/MultiTestFlightStart
2. Samples/PolySpatial/Scenes/IronManUI

MultiTestFlightStart
- Initial scene, the choices are in "SelectionCanvas > Object Selection"
- Scene Target can be changed in the Button Component of OldAVP/IronMan/NewAVP, just change the onclick script input

- SelectionCanvas has LazyFollow, which is the component used to dynamically follow the location of the camera
- Also has LazyFollowStartScript, which makes sure that the canvas only follows at the start of the app launching

- Has gameobject FollowSingleton, which is a game object that is not destroyed when moving scenes. This is required to save the initial location of the camera on launch.

IronManUI
- Mainly has IronMan UI
- StartCanvas, button to be clicked to enable the IronManUI, has script StartScript to do so
- HomeCanvas, button to be clicked to go back to MultiTestFlightStart
- LoginCanvas, initially disabled
 - Main canvas for IronManUI
 - Has multiple GameObjects for the UI
   - Which has PieceSelectionBehaviour, automatically allowing them to be tapped
   - Tapping logic in Manager > MovementUIScript
   - When clicked on, will enable movement bar and closing dot
   - UI > Reload > Reload, contains button to reset all UI to initial position and enable all as well
     - Has ReloadScript, which has input of elements which needs to be resetted
    
Video Player
- Located in IronManUI Scene
- Can be seen in UI > MainCanvas
- LeftSideMenu toggles which Panel is shown
- Panel3 is empty
- Panel2 contains the categories
- Panel1 is the main page for this feature
  - Viewport is the default view, which is scrollable
    - Contains DetailsNavigationScript, needed to navigate between home page and details page
    - "Content" Gameobject is the main scrollable view
      - BackgroundImage > DetailsButton, is the button to be clicked to navigate to details page
        - Contains script DetailButtonScript, which has several inputs to determine the background image, description, and video
        - For video, it needs to be in .mp4 format, and placed within the Resources folder. Also recommended to convert to Vision codec
        - Background image needs to be in Resources folder as well
        - For other components to lead to details page, just add DetailsButtonScript.
          - Other clickable examples: Content > FeaturedGallery > Viewport > Gallery > Image (1) / Image (5)
  - DetailsViewport is initially disabled, is the view for Details
    - Also contains DetailsNavigationScript
    - DetailsViewport > Content > BackgroundImage > DetailsButton, button to go back to home page
    - DetailsViewport > Content > BackgroundImage > PlayVideo, button to go to video page
- Video Canvas contains the video player, which is initially disabled
  - Contains several scripts:
    - NavigationVideoScript, to navigate back to details page
    - VideoProgressBar, script for the progress bar and duration text to work
    - VideoButtonControls, script for pause, rewind, fast forward, volume controls and playback speed
      - Playback speed controls is bugged for VisionOS. We can change the playbackSpeed of the video, but the change is not visible at all in the simulator

Avatar Example:
- Scene can be accessed in Samples/PolySpatial/Scenes/CharacterWalker
- In runtime, can be accessed by clicking on Old AVP Sample in the launch scene.
  - In the scene, click on the arrows until you see "CharacterNavigation", then click Play
  - Click/Tap on the floor to move the character
- In the scene, you can see the GameObject "Avatar Test"
- In order for the avatar to work within the VisionOS Simulator:
  - The controller is set as StarterAssetsThirdPerson
  - Avatar is set as FeminineAvatar
  - Culling mode is set to AlwaysAnimate (VERY IMPORTANT)
- In this scene, the avatar is custom made using ReadyPlayerMe, to import it into your own project, simply follow the instructions from their page.
- Their link is this: https://docs.readyplayer.me/ready-player-me/integration-guides/unity/quickstart
  
  
