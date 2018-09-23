### Disclaimer ###
The scripts in this folder are included to illustrate the system I used for the ragdoll puppetry and combat system in [this game](https://fishlicka.itch.io/schwing).  

### Contents ###
**Ragdollifier** - Attaches capsule colliders to a rigged model imported from blender. Colliders will require adjustment.  
**Walker** - Animates a ragdoll to walk by applying forces to the head and feet.  

**Combat/Monster** - Attach to top level of ragdolled armature to detect hits by player.wbody.  
**Combat/Hittable** - Attached by Monster script to each part of ragdoll with a collider.  
**Combat/Weapon** - Controlled by Player script to emit particles on Monster hit.  

### Combat System Layermask Scheme ###
For weapon-monster collision identification, the scripts in the Combat folder adhere to the following layerMask scheme:  
Monsters are on layermask 10.  
Weapon(s) are on layermask 9.  