import math
import sqrt_expansion
import itertools
from fractions import Fraction

target_min_total = 10 ** 12


multiplier = 0

for c_i in itertools.islice( sqrt_expansion.convergents_gen(2), 1, 33 ):

    c = Fraction(1) / c_i # since we're interested in 1/sqrt(2) convergents, inverse convergent for sqrt(2)

    print( "Starting 1/sqrt(2) convergent: {0}".format(c) )

    # determine is't greater or smaller than 1/sqrt(2)

    is_surplus = c > 1 / math.sqrt(2)
    
    while True:

        multiplier += 1
        
        c_num = c.numerator * multiplier
        c_den = c.denominator * multiplier

        if is_surplus:
            c2_num = c_num - 1
            c2_den = c_den - 1
        else:
            c2_num = c_num + 1
            c2_den = c_den + 1


        if c * Fraction(c2_num, c2_den) == Fraction(1, 2):
            
            total = max( c_den, c2_den )
            blue_disks = max( c_num, c2_num )

            print( " Arrangement: {0}/{1} x {2}/{3}. Blue disks: {4}, total: {5} (Multiplier was {6})".format(c_num, c_den, c2_num, c2_den, blue_disks, total, multiplier ) )

            if total > target_min_total:
                import sys
                sys.exit()

            break