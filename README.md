# DoorDockSpawn
 
a system for creating dock points. i'm using it to build rooms and hallways that connect at different sizes of doors.

the door docking stuff works. add a room component to the room with child game objects with the DockPoint class. you can then create some door types and it will display the gizmo overlay for the door. there's an attach room that will attach a room to the door you specify. assuming it can find a valid door to dock with. this doesn't assign the targetdoor for the local door and is mainly being used by the builder script to attempt to attach a room and validate that it's not intersecting with other rooms.

add a game object with a box colider for the area the room needs empty to spawn. add the RoomArea component to this game object.

make sure the room's dockpoints and spawn area have been linked to their properties on the room component.
