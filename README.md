# Calculating an aim ahead vector

If computer controlled tank attempts to shoot at a target, they will always miss if the target is moving relatively left or right, and if the shots are not instantaneous. To hit a target that is moving, the tank needs to aim ahead of the target so that the shot intercepts them as they move.

To calculate the aim ahead angle, we only need to know the target's velocity and the speed of our projectile. Let's start with the simplest case, where the target is directly ahead and moving to the right. This gives us the following right angled triangle:

![image](https://github.com/LSBUSGP/AimAhead/assets/3679392/8c9e6151-04dc-4f80-b3d8-eb3ddea98beb)

We can figure out the angle $a$ we need to aim ahead by using some trigonometry:
$$\sin{a} = \frac{o}{h}$$

Although we don't know the length of $o$ or $h$ as they each depend upon the variable time, we can still find the ratio. If we say:
$$v = \text{speed of target}$$
$$p = \text{speed of projectile}$$
$$t = \text{time}$$
then:
$$o = tv$$
$$h = tp$$
so:
$$\sin{a} = \frac{tv}{tp} = \frac{v}{p}$$
and, as you can see, the time variables cancel out. What this tells us is that the angle calculation does not depend on the time.

Re-arranging this we can find the angle with:
$$a = \arcsin{\frac{v}{p}}$$

This solves the simplest case, but for the most part, the target will be either moving towards or away, as well as to the right or left. In this case, we can project the target's direction vector onto a vector orthogonal to the tank's direction and then use the length of this vector as our value for $o$.
$$\vec{V} = \text{target's movement vector}$$

![image](https://github.com/LSBUSGP/AimAhead/assets/3679392/a9734e7b-6c5c-4eed-b4ef-1d0d16adcdc1)

If we can do this, then the solution is the same as above. The Unity function [Vector.Project](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Vector3.Project.html) does exactly this.

And if the target is not direction ahead of us, then we can rotate our tank to point directly at the target. Again, the solution is the same as above.

## Coding aim ahead in Unity

The steps for calculating the aim ahead are therefore:

1. turn the tank to face the target
2. project the target's movement vector onto the tank's right vector
3. use [Mathf.Asin](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Mathf.Asin.html) to calculate the relative angle
4. rotate the turret by this amount
5. fire!

Note: if in calculating the value $\frac{o}{h}$ you end up with 1 or more, this means your projectile is not fast enough to hit the target. If you try to pass more than 1 or less than -1 to the [Mathf.Asin](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Mathf.Asin.html) function, you will get an exception.
Also note: the value returned by the [Mathf.Asin](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Mathf.Asin.html) is the angle in radians.
