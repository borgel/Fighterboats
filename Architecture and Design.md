Models
======
* *MAKE UML*
    * http://stackoverflow.com/questions/168512/best-free-professional-looking-uml-tool
    * ArgoUML is installed. Try that
* map class
    * singleton?
* entity object (interface? abstract class?)
    * made from factories?
        * good for creeps for each side
    * interactible, autonomous, etc?
* player class
    * tracks
        * XP
    * inventory object
        * this stays with the player, not the boat
        * tracks $ and manages purchases for us
* boat class
    * DIFFERENT from player
    * tracks boat traits
        * name/flavor
        * abilities
        * current/max
            * health
            * speed
            * acceleration
        * hardpoints
            * number, location, type
    * drawable
        * boat model
        * hardpoints
        * modifiers
* inventory class
    * takes # of slots
    * tracks
        * $
        * what items are in what slots
        * can make purcahse
            * takes cost and items to mulch
            * asks 'item' its selling for this info?
        * can browse
        * what slots items are in
        * what hotkey triggers what items
* shop class
    * has an inventory object of its own?
        * takes payment
* item interface
    * hold all traits of anything thats an item 
    * tracks
        * cost
        * type (weapon, powerup, etc)
        * prereq items to consume
            * to double, consumes a single
            * to combine tier 1 combos, takes 2 different tier 1 combos
        * can be mounted on boat
            * if so, what sort of hardpoint it can mount to
    * drawable
        * can ask for its
            * bounds
            * inventory icon
            * hardpoint sprite
* weapon interface (implements item)
    * holds info about a weapon
    * tracks
        * restrictions (ship only)
* powerup interface (implements item)
    * holds a non-weapon object
    * tracks
        * bonuses granted
            * speed
            * accele
            * stealth
            * sight range
            * health
* network feedback interface
    * broadcast state changes like
        * move
        * purcahse complete
        * killed
* movable interface
    * execute moves


Network Play
============
* hub and spoke
    * spokes are clients
    * hub is server console running on a machine
* use protobufs?
    * only between 1 kind of client, so not sure it really matters

Playing
-------
* each client calculates ALL FACETS of it's player's universe
    * ship position
    * projectile position
    * items
        * purchase order can go through hub for validation?
    * fog visibility?
    * player health
    * if a projectile hits or not
    * XP
* when the client updates a trait (position, direction, purchase, health, hits, etc) send to hub, then broadcast to all clients
* when each client receives an update, they update their internal representaitons of all models
* server runs creeps, towers, and all NPCs
* server manages timekeeping for match (battle rounds, creep spawns, time of day, etc)
* server manages game state (start, stop, pause, round end)
* server manages score
* server can command clients to pause
* server can broadcast messages/popups to players
    * 'game over', etc

Joining
-------
* client connects to server (via IP/hostname first, broadcast later?)
* server shows list of games (or just run 1 game always for now?)
* server checks client build timestamp (as a version. Must match)
* server tells client what map to load
* server displays game start countdown
* server starts/ends play

What If Web Based
-----------------
* what if server is really webserver, and all clients are just webpages
* people navigate to the server's hostname, server loads plugin JAR, server makes all connections in its own backend
* should be nearly interchangible with normal desktop client builds


UI
==
* https://github.com/libgdx/libgdx/wiki/Scene2d
* maybe have central screen manager instead of drawing in all these different screens by manually instantiating them
    * reuse camera, sprite batches, etc between screens
    * manager receives inputs and send them to the screens. Swaps screens in and out
    * needed? is this baked into framework already?
        * or do we just do something in scene2D to do it
    * 


Menu's
======
* use scene2D.ui from GDX
    * https://github.com/libgdx/libgdx/wiki/Scene2d.ui
    * https://github.com/EsotericSoftware/tablelayout
* intro screen
    * settings
        * graphics
        * gameplay
        * sound
    * map select
        * waiting room


Random Notes
============
* physics
    * what if movement is governed by physics? IE boats have an acceleration. Could be worth trying
* menu's in JSON files too?
    * can each screen/layer of HUD be an individual file
* define everything in individual json files
    * boats/shops
* utilities
    * getMaps()
    * getMap()
        * returns pre-filled map object?
* map files?
    * directories with JSON files and a TMX file (of the map)
    * http://www.mapeditor.org/
