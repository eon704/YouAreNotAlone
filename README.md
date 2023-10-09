# The Lost Spirit

A top-down 2D survival game, submission for the [Brackeys Game Jam 2022.2](https://itch.io/jam/brackeys-8).

`Theme: You are not alone.`

Play the game at [itch.io](https://eon704.itch.io/the-lost-spirit).

# Story

The Guardian Spirit of the Maple Forest was on its way to the Tree of Life in the Sacred Forest. 

However, something happened along the way.  The Spirit found itself lost, in a deep dark cave. Will you find the way out?

- Find the fellow Forest Spirits.
- Save the lost souls you find along the way.
- Don't let the devils come close and make them disappear with the spell.

# Screenshots:

<img width="1512" alt="Cover" src="https://github.com/eon704/YouAreNotAlone/assets/16372290/d2d41f0d-009f-4667-9361-f7dd8e0cedec">

![Dialogue](https://github.com/eon704/YouAreNotAlone/assets/16372290/d8e0cba5-2e1d-4a6c-a255-55a9155a2e5f)

![Battle](https://github.com/eon704/YouAreNotAlone/assets/16372290/b2f7bebe-184c-4594-9c59-a5a8c005a906)


# Notes:
- Used URP for 2D lights attached to the player and to the enemies.
- Used Interface to unify the health, damage, and death logic.
- Used UnityActions to communicate events in the game. Particularly changes to UI.
- Used Singleton with `DontDestroyOnLoad` to enable playing the level music continuously without interruptions during the scene change.
- Implemented Dialogue System.
