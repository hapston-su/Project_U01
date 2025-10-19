# \#  Behind the Enemy Lines (Tank Battle Game)

# 

# A simple 3D \*\*Tank Shooter\*\* built in \*\*Unity\*\*, featuring player control, enemy AI, projectile mechanics, explosions, and sound effects.

# 

# ---

# 

# \## 🎮 Gameplay Overview

# 

# \*\*Objective:\*\*  

# Survive and destroy as many enemies as possible before they reach your tank.

# 

# \*\*Core Gameplay Loop:\*\*

# 1\. Rotate your tank using horizontal arrow keys.

# 2\. Shoot shells using the \*\*Spacebar\*\*.

# 3\. Enemies drive toward the player.

# 4\. Destroy enemies with shells to earn points.

# 5\. The game ends when the player collides with an enemy.

# 

# ---

# 

# \## 🕹️ Player Controls

# 

# | Action | Key |

# |--------|-----|

# | Game Pause | Esc |

# | Turn Left / Right | ← / → |

# | Shoot shell | Spacebar |

# 

# ---

# 

# \## ⚙️ Game Mechanics

# 

# \- \*\*Player Movement\*\* — controlled using Unity’s `transform.Rotate()`.

# \- \*\*Enemy Behavior\*\* — each enemy moves toward the player using a simple AI script (`LookAt` + forward movement).

# \- \*\*Projectile System\*\* — shells are spawned and move forward using `transform.Translate()` until hitting an enemy.

# \- \*\*Explosion Effects\*\* — on impact, a particle explosion and sound effect play. when shell collide enemy or enemy collide the player.

# \- \*\*Game Over Condition\*\* — triggered when an enemy collides with the player.

# 

# ---

# 

# \## 🧩 Scripts Overview

# 

# | Script | Description |

# |--------|--------------|

# | `PlayerController.cs` | Handles player movement and shooting. |

# | `Projectile.cs` | Controls shell speed, lifetime, and collisions. |

# | `EnemyFollow.cs` | Makes enemies move toward the player. |

# | `DetectCollisions.cs` | Detects collisions and triggers explosions or game over. |

# | `DeleteAfterExplosion.cs` | Delete the spawn Particle System prefabs for creating explosion effect and sound. |

# | `DifficultyLevel.cs` | Controls the UI slider and the game difficulty levels (speed of the enemy, number of enemy tanks ). |

# | `SpawnManager.cs` | Spawns enemies at set intervals (stops when game over). |

# | `GameManager.cs` | Controls game state (start, game over, restart). |

# 

# ---

# 

# \## 💥 Effects and Audio

# 

# \- \*\*Explosion Particles:\*\* Triggered when an enemy is destroyed.  

# \- \*\*Explosion Sound:\*\* Plays using `AudioSource.PlayClipAtPoint()` | Play on wake for the spawn explosion prefabs.  

# \- \*\*Audio Setup Tips:\*\*

# &nbsp; - Attach an `AudioSource` to each prefab.

# &nbsp; - Disable "Play On Awake" if you only want it triggered by collisions. tried both attaching audio to player prefab as well as spawning new explosion and sound prefab after detecting collison

# &nbsp; - Ensure volume and 3D sound settings are tuned for gameplay.

# 

# ---

# 

# \## 🧠 Collision Handling

# 

# \- \*\*shell → Enemy:\*\* Destroys both and spawns explosion.  

# \- \*\*Player → Enemy:\*\* Triggers \*\*Game Over\*\* state.  

# 

# \### Code Reference:

# ```csharp

# private void OnTriggerEnter(Collider other)

# {

# &nbsp;   if (other.CompareTag("Player"))

# &nbsp;   {

# &nbsp;       FindFirstObjectByType<GameManager>().EndGame();

# &nbsp;       FindFirstObjectByType<PlayerController>().PlayerExplosion();

# &nbsp;   }

# &nbsp;   else

# &nbsp;   {

# &nbsp;       Instantiate(enemyExplosionPrefab, transform.position, transform.rotation);

# &nbsp;       AudioSource.PlayClipAtPoint(explosionSound, transform.position);

# &nbsp;       Destroy(other.gameObject);

# &nbsp;       Destroy(gameObject);

# &nbsp;   }

# }



