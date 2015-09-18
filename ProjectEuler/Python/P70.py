import project_euler
import itertools
import operator
import functools
import sys

def phi(x):
    val = x
    for f in project_euler.distinct_factors(x):

        if f != 1:
            val *= f - 1
            val = val // f

    return val

def permutational_eqivalent(x, y):

    if not isinstance(x, str): x = str(x)
    if not isinstance(y, str): y = str(y)

    return sorted(list(x)) == sorted(list(y))


# brute force
cur_min = 1000000

for x in range(10 ** 7, 1, -1):
    phi_value = phi(x)

    if x % 10000 == 0: print("working {0}".format(x))

    if permutational_eqivalent( str(phi_value), str(x)):
        
        val = x / phi(x)

        if val < cur_min:
            print("x={0}, x/phi={1}".format(x, val))
            cur_min = val

#print(permutational_phi_arg)
#print(sorted(permutational_phi_arg, key=lambda x: x / phi(x), reverse=True)[:100])

#primes = project_euler.eratosphen_primes(1000)[:20]

#print(primes)

#for n in range(10, 1, -1):
#    for c in itertools.combinations(primes, n):
#        x = functools.reduce(operator.mul, c, 1)

#        if x > 10 ** 7: continue

#        print("{0}, {1}".format(c, x))

#        if permutational_eqivalent(phi(x), x):
#            print("---FOUND---")
#            print(x)
#            print(phi(x))
#            sys.exit()