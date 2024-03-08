# Calculating an aim ahead vector

If computer controlled tank attempts to shoot at a target, they will always miss if the target is moving relatively left or right, and if the shots are not instantaneous. To hit a target that is moving, the tank needs to aim ahead of the target so that the shot intercepts them as they move.

To calculate the aim ahead angle, we only need to know the target's velocity and the speed of our projectile. Let's start with the simplest case, where the target is directly ahead and moving to the right. This gives us the following right angled triangle:
