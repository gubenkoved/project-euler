import math
import time
import itertools
import functools

def maximal_root(n):
    """ Returns the largest integer x for which x * x does not exceed n """
    x = n
    y = (x + 1) // 2
    while y < x:
        x = y
        y = (x + n // x) // 2
    return x

def is_square(x):
    """ Checks that passed integer is square (4, 16, 25, etc) """
    mr = maximal_root(x)
    return mr ** 2 == x

def is_prime(x):
    """ Checks that passed integer is prime """
    if x <= 1:
        return False
    elif x == 2 or x == 3:
        return True
    else:
        for d in range(2, math.ceil(math.sqrt(x) + 1)):
            if x % d == 0:
                return False
        return True

def eratosphen_primes(max):
    
    max = int( max )

    primes = []
    e = [True] * max
    for r in range(2, max):

        if e[r]: # r is prime
            primes.append(r)

            for idx in range(r, max, r):
                e[idx] = False

    return primes
 
def flatten(list2d):
    from itertools import chain
    return list(itertools.chain.from_iterable(list2d))

def timing(method):
    def inner(*args):
        start = time.time()
        
        print("Timing method {0}...".format(method.__name__))
        
        method(*args)

        elapsed = time.time() - start

        print("Elapsed {0:.3f} s.".format(elapsed))
    return inner

def gcd(x, y):
    if y == 0:
        return x
    else:
        return gcd(y, x % y)

def factorize(x):
    factor = None

    for f in range(2, math.ceil(math.sqrt(x) + 1)):
        degree = 0
        while x % f == 0:
            factor = f
            x = x // f
            degree += 1

        if degree > 0:
            break
   
    if not factor is None:
        return [[factor, degree]] if x == 1 else [[factor, degree]] + factorize(x)
    else:
        return [[x, 1]]

def factorize_flat(x):
    factors_flat = []

    for factor in factorize(x):
        factors_flat += [ factor[0] ] * factor[1]

    return factors_flat

   
def distinct_factors(x):
    return [fp[0] for fp in factorize(x)]

def report_progress(completed_fraction):
    print( '\r[{0:100}] {1:4.1f}%'.format('#' * int(completed_fraction * 100), completed_fraction * 100), end='' )

    if completed_fraction == 1:
        print('')