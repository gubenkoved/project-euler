import project_euler

def sum_of_prime_factors(x):
    return sum( [f for f in range(2, x + 1) if project_euler.is_prime(f) and x % f == 0 ] )

__cache = {}

def prime_partitions(n):

    if n in __cache:
        return __cache[n]

    if n == 1: return 0

    s = sum_of_prime_factors(n)

    for j in range(1, n):
        s += sum_of_prime_factors(j) * prime_partitions(n - j)

    r = s / n

    __cache[n] = r

    return r

n = 1

while True:
    n += 1
    pp = prime_partitions(n)
    print("n={0}, prime partitions={1}".format(n, pp))

    if pp > 5000:
        break

#print(sum_of_prime_factors(10))