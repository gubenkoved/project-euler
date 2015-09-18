import math

target_ratio = 3 / 7
min_delta = 1

def smaller_relative_primes(x):
    r = []
    for y in range(math.floor(x * target_ratio * 0.999), math.ceil(x * target_ratio)):
        if y != 0 and x % y != 0:
            r.append(y)

    return r

for d in range(10 ** 6, 1, -1):
    for n in smaller_relative_primes(d):
        v = n / d

        if v < target_ratio and target_ratio - v < min_delta:
            min_delta = target_ratio - v
            solution = [n, d]
            print("{0}, error: {1}".format([n, d], min_delta))
