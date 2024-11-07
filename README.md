# Calculating an aim ahead angle

A computer controlled tank aiming at a target will always miss if its target is moving fast enough and its shots are not instantaneous. To hit a moving target, the tank needs to aim ahead. To calculate the aim ahead angle, we only need to know the target's velocity and the speed of our projectile.

https://github.com/user-attachments/assets/951ff037-f6bb-4572-b301-aad8ee638167

## The simplest case

Let's start with the simplest case, where the target is directly ahead and moving to the right. This gives us the following right angled triangle:

![illustration of a tank aiming at a target ahead](https://github.com/LSBUSGP/AimAhead/assets/3679392/8c9e6151-04dc-4f80-b3d8-eb3ddea98beb)

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

Note: if in calculating the value $\frac{o}{h}$ you end up with 1 or more, this means your projectile is not fast enough to hit the target. The $\arcsin$ function is undefined for values more than 1 or less than -1. The Unity function [Mathf.Asin](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Mathf.Asin.html) will perform this calculation.
 
This solves the simplest case, but in practice, the target is unlikely to be moving at exactly $90\degree$.

## A more usual example

In general, we can project the target's direction vector onto a vector at $90\degree$ and use the length of this projection as our value for $v$.
$$\vec{V} = \text{target's movement vector}$$

![illustration of a tank aiming at a target moving right and forward](https://github.com/LSBUSGP/AimAhead/assets/3679392/4a93d3fe-e27d-4fb4-b4e1-148382fa3868)


Note: in this illustration we still don't know $t$. But again we can find our ratio by cancelling out the $t$ values.

To find the length of the target's movement vector projected onto our tank's right vector we can take the dot product of the vector $\vec{V}$ with a unit vector pointing to our tank's right $\vec{R}$.
$$v = \vec{V}\cdot\vec{R}$$

With this new value for $v$ we can use the same trick as above to calculate the angle.

## What if we aren't pointing at the target?

If the target is not directly ahead, the we can rotate our tank until it is. And again, the solution is the same as above.

## Coding aim ahead in Unity

The steps for calculating the aim ahead are therefore:

- turn the tank to face the target
- find the dot product of the target's movement vector with our tank's right unit vector
- use [Mathf.Asin](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Mathf.Asin.html) to calculate the relative angle
- rotate the turret by this amount
- fire!

Note: the value returned by the [Mathf.Asin](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Mathf.Asin.html) is the angle in radians. You can use [Mathf.Rad2Deg](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Mathf.Rad2Deg.html) to convert it.
