import itertools
import sys
import math
from project_euler import *

def replaceWith(lst, indexes, replacement):
    result = list(lst)
    for idx in indexes:
        result[idx] = replacement

    return result

x = 56002
checked_masks = set([])
while True:

    x += 1

    if not is_prime(x):
        continue

    x_string = str(x)
    n = len(x_string)
    prime_count = 0

    #print('Checking {0}'.format(x))

    for replacement_len in range(1, n):
        # print ('Trying with replacement len {0}'.format(replacement_len))
        for to_be_replaced in itertools.combinations(range(n), replacement_len):
            
            x_digit_list = list(str(x))        
            mask = "".join(replaceWith(x_digit_list, to_be_replaced, '*'))
            primes_found_by_mask = []

            if (mask in checked_masks):
                continue
            else:
                checked_masks.add(mask)

            #print(" replacing following: {0}".format(to_be_replaced))

            for digit in map(lambda d: str(d), range(10)):

                x_digit_list = replaceWith(x_digit_list, to_be_replaced, digit)

                if x_digit_list[0] == '0':
                    continue

                to_check = int("".join(x_digit_list))
                
                if is_prime(to_check):
                    #print ('  prime! {0}'.format(to_check))
                    primes_found_by_mask.append(to_check)

            if (len(primes_found_by_mask) > 5):
                print(" mask was: {0}, found {1} primes: {2}"
                          .format(mask,
                             len(primes_found_by_mask),
                             primes_found_by_mask ))

            if (len(primes_found_by_mask) == 8):
                sys.exit()
