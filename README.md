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
    
## Sprint 3
## Comments
- any commits by user "ch3ney" is done by skansher on a different device due to technology issues - not a different user
## Controls:
- controls are the same as sprint 3
- special controls to change player health will be removed later, used currently for testing purposes
## known bugs:
- game hud does not follow camera
- game hud timer needs to be debugged - issues with GameTime gametime
  
