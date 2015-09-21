from itertools import combinations

sq = [("{0:2}".format(x**2)).replace(' ', '0')
      for x in range(1, 10)]

def expand_six_nine(s: set):
    if '6' in s:
        s.add('9')

    if '9' in s:
        s.add('6')

def is_suitable(s1: set, s2: set) -> bool:

    expand_six_nine(s1)
    expand_six_nine(s2)

    for x in sq:
        # possible to write x as cubes with s1 and s2 digits on sides
        d1 = x[0]
        d2 = x[1]

        if not(d1 in s1 and d2 in s2
            or d1 in s2 and d2 in s1):
            return False

    return True

s1 = set(['1', '5', '6', '7', '8', '9'])
s2 = set(['1', '2', '3', '4', '8', '9'])


# print( is_suitable(s1, s2 ) )

ca = list( combinations(["{0}".format(x) for x in range(10)], 6))

solutions = []

for c1 in ca:
    for c2 in ca:
        if is_suitable(set(c1), set(c2)):
            sol = [ c1, c2 ]
            print(sol)
            solutions.append(sol)

print(len(solutions))
