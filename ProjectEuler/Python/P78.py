import project_euler
import functools
import math

@functools.lru_cache(100000)
def pentagonal(k):
    return k * (3 * k - 1) // 2


@functools.lru_cache(100000)
def p(n):

    if n == 0: return 1
    elif n < 0: return 0

    k_min = math.floor((1 - math.sqrt(1 + 24 * n)) / 6)
    k_max = math.ceil((1 + math.sqrt(1 + 24 * n)) / 6)

    r = 0

    for k in range(k_min, k_max + 1):
        
        if k != 0:
            r += int((-1) ** (k - 1)) * p(n - pentagonal(k))

    return r

@project_euler.timing
def p78():
    n = 0

    while True:
        n += 1
        pp = p(n)

        if n % 10 == 0:
            print("n={0}, partitions={1}".format(n, pp))

        if pp % 10 ** 6 == 0:
            print("n={0}, partitions={1}".format(n, pp))
            break

p78()