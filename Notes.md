Notes
=====

2D/3D
-----
* might just want to do 3d. Is it easier technically? art is harder

Pathfinding
-----------
* navmesh generates offline all allowable paths
* navmesh agent (component) can be bound to a GameObject, can give it AI to follow navmesh and go to a target
    * may need more and more hacking long term, but looks like its enough for creeps and players for now!
    * target can be any transform (I guess). So it can be a player, and it will constantly go to the player
* I assume it can be an XY location, and it will go there (AKA to where a player clicks)
* https://www.youtube.com/watch?v=TD11AzSQ0Ao

Networking
----------
* oh man, Unity does practically everything
* can manually serialize/deserialize, but looks like by default it can automagically sync properties (AKA transforms) of an object to all players on network. So initially, dont need any custom serialize/deserialize
* if we trust the clients, they can do all shooting themseslves (for ONLY their player)
    * When their boat shoots (or whatever), it'll autoamtically draw that on all other player's laptops
    * when someone dies, that will be automatically reported too?
    * MAY NEED RPC for things like death
        * when your client calcualtes it shot someone, it calls the KILL RPC on them? Then server updates everyone? or then server calls KILL back on them? not sure
    * will need custom network serial/deserial to sync inventory state I guess?

Fog of War
----------
* how?
* Flood fill for max radius # around player?
* check all points withing radius # of player, and check if the line connecting that point to the player passes through any material tagged as 'clif'. If it does, that area is shadow. If not it is clear
    * holy shit snacks code for this sort of exists. See 'player sight' here: http://unity3d.com/learn/tutorials/projects/stealth/enemy-sight. You can cast a ray along a vector and see if it collids with something!

Boats
-----
* can we attach guns to the boat as if they were parts of a 2D body?
