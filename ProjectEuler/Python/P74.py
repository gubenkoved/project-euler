import math

def __factorial_chain_next(x):
    return sum( [math.factorial(int(y)) for y in list(str(x))] )


__cache = {}
def __factorial_chain_len_recursive(x, nums):

    if x in __cache:
        return __cache[x]

    next = __factorial_chain_next(x)
    if next in nums:
        return 0
    else:
        res = 1 + __factorial_chain_len_recursive(next, nums + [next])

        __cache[x] = res

        return res

def factorial_chain_len(x):
    return 1 + __factorial_chain_len_recursive(x, [x])


answer = 0
for x in range(1, 10 ** 6):
    l = factorial_chain_len(x)
    if l == 60:
        print("{0} -> {1}".format(x, l))
        answer += 1

print(answer)
print("cache size: {0}".format(len(__cache)))