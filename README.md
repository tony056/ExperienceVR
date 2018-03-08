## ExperienceVR
==========================

<!-- # All event names
    1. Input Events
        1. Trigger Event
            - select obj: selectTrigger (open the UI window)
        2. Create/Manipulate Animation:
            - add: addAnim (add now editting animation into the timeline)
            - select obj: selectAnimTarget
            - save init transform: saveAnimInit
            - save final transform: saveAnimFinal
            - play: playAnim
            - pause: pauseAnim
            - remove: removeAnim
        3. Behavior timeline
            - select anim: selectAnim
            - adjust start time/duration: updateAnimAttr
            - play: playBehaviour:
            - pause: pauseBehaviour
            - remove: removeBehaviour
            - add: addBehaviour (save now editting behavior) -->

## Development Environment
1. Unity 2017.3


## Photon Network Object
- PhotonCommsManager
- PhotonGameObject

## Set up a new scene
- grab _PhotonCommsManager_ prefab in Resources folder into the scene.
- create scene and scene objects
- create players

## Create a network synchronized object
1. right click in the hierarchy view, and then select option *Scene Object*
2. A _PhotonGameObject_ will be created.
3. Put the 3d model under the _PhotonGameObject_
4. the _PhotonGameObject_ will help you handle attribute synchronization.


## Set up multi players
1. Please take a look at _PhotonCommsManager_
2. the script creates PCPlayer as the master, and Player as the client.
3. You should create a new Player (with Vive setup) prefab in Resources  folder and call it in _PhotonCommsManager_ script.
