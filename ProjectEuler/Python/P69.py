import project_euler

def phi(x):
    val = x
    for f in project_euler.distinct_factors(x):

        if f != 1:
            val *= f - 1
            val = val // f


    if x % 1000 == 0:
        print (x)

    return val

max = -1
n = -1

for x in range(1, 1000000):
    cur = x / phi(x)

    if cur > max:
        max = cur
        n = x

print ("Answer: {0}".format(n))