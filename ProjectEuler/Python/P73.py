import project_euler
import math

count = 0
for d in range(2, 12000 + 1):
    for n in range(max(1, math.floor(d / 3)), math.ceil(d / 2)):
        if n / d > 1/3 and n / d < 1/2:
            if project_euler.gcd(n, d) == 1:
                count += 1

    if d % 120 == 0:
        print('.', end="", flush=True)

print(count)
