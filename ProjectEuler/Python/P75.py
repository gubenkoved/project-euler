import project_euler
import math

l_limit = 1500000

# ref: http://mathforum.org/library/drmath/view/55757.html

# a = (r^2 - s^2)*d,
# b = 2*r*s*d,
# c = (r^2 + s^2)*d,

l_dict = {}

for r in range(2, math.ceil(math.sqrt(l_limit / 2))):
    s = 0
    while True:
        s += 1

        if s >= r:
            break

        a = r ** 2 - s ** 2
        b = 2 * r * s
        c = r ** 2 + s ** 2

        l = a + b + c

        if l > l_limit:
            break

        if (s % 2 == 0) ^ (r % 2 == 0) \
            and project_euler.gcd(s, r) == 1:

            # (r,s) produces primitive pythogorian right triangle
            print("r = {0}, s = {1}".format(r, s))

            d = 0
            while True:
                d += 1
                
                (a_s, b_s, c_s) = (a * d, b * d, c * d)
                l_s = a_s + b_s + c_s

                if l_s > l_limit:
                    break

                #print("({0}, {1}, {2}) L={3}".format(a_s, b_s, c_s, l_s ))

                if not l_s in l_dict:
                    l_dict[l_s] = 0

                l_dict[l_s] += 1

        

#for key in sorted(l_dict, key=lambda x: (l_dict[x], -x), reverse=True):
#    print("{0}: {1}".format(key, l_dict[key]))

solution = sorted([x for x in l_dict if l_dict[x] == 1])

print(len(solution))
#print(solution)