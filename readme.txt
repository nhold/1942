1942 - By Nathan Hold
---------------------

Here are some notes:

* The system has a little of both worlds using interfaces and some pure component design just to showcase how I do different things.
* The UML was done to get something for me to follow, I didn't do stuff like UI or anything like that as it gets a little crazy for Unity.
* I wanted to do an Object Pooling system, but didn't have time. I could have easily gotten an open source on like: https://github.com/prime31/RecyclerKit for a nice performance boost.
* I hope my scenery passes as a 'star field' even though it isn't very efficient (All scenery has it's own movement rather than being managed from some SceneryHandler or manager or just being another scrolling background).
* Enjoy reading the code!

The code will also be available at my github: https://github.com/nhold

I think the system is pretty robust because projectiles and ships can have the same movement schemes (I.e you can easily make a projectile zig zag like some enemies do) plus
it's easy to add a dual cannon (Same as a SingleProjectileWeapon but it spawns two next to the given spawn position). One could even just write a MultiShotCannon that scales 
up the number of projectiles based on some number. Using this you could also write larger boss by extending from enemy ship and adding a Life component to it, then give it
children gameobjects that are 'EnemyShips' with no MovementStrategy with WeaponControllers and with Life components as well.

All files in this project are subject to the following licence and copyright or the licence and copyright of their respective owners.

/*
 * Copyright (c) 2015 Nathan Hold<nathanhold@hotmail.com>
 * 
 * All rights reserved. No warranty, explicit or implicit, provided.
 * In no event shall the author be liable for any claim or damages.
 */