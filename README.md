# Calculating an aim ahead vector

If computer controlled tank attempts to shoot at a target, they will always miss if the target is moving relatively left or right, and if the shots are not instantaneous. To hit a target that is moving, the tank needs to aim ahead of the target so that the shot intercepts them as they move.

To calculate the aim ahead angle, we only need to know the target's velocity and the speed of our projectile. Let's start with the simplest case, where the target is directly ahead and moving to the right. This gives us the following right angled triangle:

![image](https://github.com/LSBUSGP/AimAhead/assets/3679392/ecc83312-2618-4102-891c-38e6ce281b26)

We can figure out the angle $a$ we need to aim ahead by using some trigonometry:
$$\sin{a} = \frac{o}{h}$$

Although we don't know the length of $o$ or $h$ as they each depend upon the variable time, we can still find the ratio. If we say:
$$v = \text {speed of target}$$
$$p = \text {speed of projectile}$$
$$t = \text {time}$$
then:
$$o = tv$$
$$h = tp$$
so:
$$\sin{a} = \frac{tv}{tp} = \frac{v}{p}$$
and as you can see, the time variables cancel out. What this tells us is that the angle calculation does not depend on the time.

Re-arranging this we can find the angle with:
$$a = \arcsin{\frac{v}{p}}$$
