# Boshi_Project
## Mario Game Project for CSE 3902. 
## Team:
1:50 section Team Boshi
Muskan, Jerrin, Ismail, Michael, Scott, Ben
## Documentation
    - Code review/metrics in folder in master
    - Planning and tasks under Github Projects
    - url: github.com/scottc2000/Boshi_Project
## Sprint 2
## Controls:
  - Mario:
    - wasd movement
    -D1, D2, D3, D4, Q state changes
  - Luigi:
    - ijkl movement
    - D8, D7, D6, D5
  - Blocks/Obstacles:
    - t, y cycle between blocks
  - Itmes:
    - v, b cycle between items
  - Enemy/NPC:
    - o, p cycle between enemies
  - Other:
    - escape quit
    - D0 reset to initial state
## Known Bugs: 
    - Items cycle through at alarming speed
    - particles not animated yet for characters (mario,luigi)
    - items and blocks do not reset
    - items and blocks get passed protected variables from main game (sprint0)
    - a few manual merging on the master branch due to complicated merge conflicts. will be fixed in the future with more frequent pulls/branches and efficient .gitignore file

## Sprint 3
## Controls:
    - Blocks, Items, and enemy controls from Sprint 2 removed
    - Luigi movement changed to arrow keys, mario remains the same

## Known Bugs:
    Player physics do not function as they would in the final game (backlog)
    Projectiles are not loaded and do not have collision components (backlog)
    Collisions are not completely functional yet. Players collide with each other mostly correct but sometimes don't register when a player moves while another player is still. Player/Enemy collisions are not functional. (backlog)
    Gravity has not been implemented due to block collisions not being done (backlog)
    Camera follows mario but screenscrolling is buggy (backlog)
    
## Sprint 4
## Controls:
    - Same as before
    - special controls to change player health will be removed later, used currently for testing purposes
## Known Bugs:
    Blocks have collision but do not react when hit (backlog)
        - Need to add question block item spawning and yellow brick bump animation
        - Block interactions need to be added - item spawning from question block and bump animation for question block and brick
    - When player is small, they can clip through the floor in certain areas most likely due to hitbox
    - Unable to trigger enemy stomped conditions
    - game hud moves horizontally but not vertically - needs to be refactored to move based on camera movement
    - game hud needs power boost sprite and logic after camera movement is fixed (need to see the gamehud at all times to test power boost)
    - game hud timer needs to be debugged - issues with GameTime gametime
    - Camera is stuttery due to oscillating position from block collision
    - Mario projectiles do not generate but Luigi's does. Raccoon power physics and logic works, but sprite changes need to be adjusted
    - Need to remove all magic numbers and strings - only some were removed
    - Need to create physics class
    - screen changes and game states need to be added
## Comments
- any commits by user "ch3ney" is done by skansher on a different device due to technology issues - not a different user
## Sprint 5
## Controls:
    - Mario: WASD Movement, E for fire power, W to fly after racoon boost
    - Luigi: Arrow Key Movement, M for fire power, Up Arror to fly after racoon boost
## Special Features
    - Mutliplayer (mario and luigi)
    - AI: Goombas swarm players
    - AI: Bowser follows and attacks players
## Known Bugs:
    - Enemies don't have "damaged" transition like Mario and Luigi (aesthetic bug)
    - Player/Enemy movement may be laggy at times (efficiency issue)
    - Game Hud doesn't have end of game "special card" ability due to Bowser Fight instead of goal
    - Coins from blocks have fast animation
    - Game reset doesn't have full functionality after Title Screen
    - Camera Y movement may be snappy depending on player position
    - Goomba enemies do not have gravity affecting them
