Mechanic:
  The mechanic I prototyped is the dodge-roll from Dark Souls. 
  Stripped to its basics, on performing the dodge action, the character has a short period of not taking damage.
  In my prototype, I have removed the roll, as it is aesthetic.
Architecture:
  Event triggers: Implemented events like TakeDamage to decouple interactions between the enemy and the player.
    Also used a player death event to communicate between the player and health UI.
  Lifetime cycles: Used throughout scripts to get references on start, as well as trigger functions on an object being enabled and disabled.
  Time.DeltaTime: Used for Camera Movement to make it independant of framerate.
Scope:
  My scope did change slightly. The polished mechanic keeps physics collision with walls and objects while negating damage.
  Due to time constraints, I was only able to set up 'enemy collision' where you collide with an enemy, and get hurt, but dodging ignores this collisions.
