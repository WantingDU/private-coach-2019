# private-coach-2019

## Requirements
This project requires Unity version 2019.4 or superior, and the functionalities of Openpose for Unity is currently only suported on Windows OS.

## Outline
"MyPrivateCoach" is a software that assists users in indoor exercise through posture recognition powered by Openpose. A 3D humanoid model called "virtual coach"
is animated by humanoid animation file choosed by user, and an evaluation system is implemented to evaluate similarity of poses of user and virtual coach in real time. At the moment, our method is based on the angle of each observable joint. 

Two type of feedback are implemented: 
- During the sport exercise, a score indicating the overall similarity of the actions is displayed below the screen, while on the virtual coach's model, red balls appear on some joints evaluated to be acting incorrectly to prompt the user.
![](https://github.com/WantingDU/private-coach-2019/raw/main/Assets/Media/notification.png)
- At the end of the sport exercise, statistics for the entire session are also available.
![](https://github.com/WantingDU/private-coach-2019/raw/main/Assets/Media/statistic.png)

We provide 4 type of exercices to choose from and an interface to configure sport sessions.
![](https://github.com/WantingDU/private-coach-2019/raw/main/Assets/Media/interface.PNG)

We used Playfab in this projet for a login system and a simple database as well, where we stock information about different sports such as which joints to evaluate.
Please change the playfab ID with your own Playfab ID.

The project is composed of two parts, one is the content of this Repo, the software for ordinary users, and the other is for [professionals](https://github.com/WantingDU/ThreeDPoseUnityBarracuda) to generate animation files of sports from video .
![](https://github.com/WantingDU/private-coach-2019/raw/main/Assets/Media/Tech_diagram.png)
 
## Utilisation
- Run getPlugins.bat located in Assets/OpenPose/
- Run getModels.bat located in Assets/StreamingAssets/models/
- Change the playfab ID in PlayFabSettings.staticSettings.TitleId, and in Assets/Scripts/PlayFabLogin.
- Our two scenes "Login" and "OpenposeCoach" are located in Assets/Scenes/,the "Login" is for a login system and once logged in, you will be redirected in the scene "OpenposeCoach".

## Resources and licenses
### Client app
- Openpose Unity plugin</br>
https://github.com/CMU-Perceptual-Computing-Lab/openpose_unity_plugin

- godot 3D mannequin </br>
We follow the godot License Terms.</br>
https://github.com/GDQuest/godot-3d-mannequin </br>

### Pro app:
- ThreeDPoseUnityBarracuda
https://github.com/WantingDU/ThreeDPoseUnityBarracuda#threedposeunitybarracuda

- Easy motion recorder:
https://github.com/neon-izm/EasyMotionRecorder
