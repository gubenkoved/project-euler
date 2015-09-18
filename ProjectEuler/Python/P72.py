import project_euler

def phi(x):
    val = x
    for f in project_euler.distinct_factors(x):

        if f != 1:
            val *= f - 1
            val = val // f

    return val

print(sum([phi(x) for x in range(2, 10 ** 6 + 1)]))