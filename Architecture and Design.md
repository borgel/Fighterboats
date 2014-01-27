New (With Unity)
================
* looks like base things should all be prefabs (hero boats, creep, tower, shop)
    * I think they can be customized per instance, but all the base functions of those things will be the same between instances. So DRY!
* 




Models (Classes)
----------------
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



What If Web Based
-----------------
* what if server is really webserver, and all clients are just webpages
* people navigate to the server's hostname, server loads plugin JAR, server makes all connections in its own backend
* should be nearly interchangible with normal desktop client builds


Random Notes
------------
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
