# all that was here before was wrong...
# need to start from scratch

# paper ref.: http://www-users.mat.umk.pl/~anow/ps-dvi/si-krl-a.pdf
# http://www.mathblog.dk/project-euler-88-minimal-product-sum-numbers/

from project_euler import factorize
from project_euler import factorize_flat
from project_euler import flatten

from functools import lru_cache
from math import sqrt

k_max = 12000

mps = [None] * (k_max + 1) # array for minimal product sum number we will find

# math insight from the ref. paprer: 2k >= mps(k) >= k

def product( ar ):
    from functools import reduce

    return reduce(lambda x,y: x * y, ar, 1)


def all_factorizations( x ):
    return __all_factorizations(x, x)

def __all_factorizations( x, max_factor ):
    for factor in range(2, min(int(sqrt(x) + 1), max_factor + 1)):
        if x % factor == 0:
            #print( "  {0}, f{1}".format(x, factor))
            
            if x == factor:
                yield [factor]
            else:

                for branch in __all_factorizations(x // factor, factor):
                    yield [factor] + branch

    yield [x]

def factorize_and_store_mps( x ):

    for factorized in all_factorizations(x):

        #print( " {0} = {1}".format(x, factorized) )

        prd = product( factorized )
        sm = sum( factorized )

        if prd >= sm:
            ones_to_add = prd - sm
            k = len(factorized) + ones_to_add

            #print( "  product-sum if we add {0} ones".format(ones_to_add) )

            # store if we not out of range
            if k <= k_max:
                mps[k] = prd if mps[k] is None else min( prd, mps[k] )

for x in range(2, 2 * k_max + 1):
    factorize_and_store_mps( x )

for k in range(2, k_max + 1):
    print( "{0} -> {1}".format(k, mps[k]) )

print( "ANSWER: {0}".format(sum(set(mps[2:]))) )
