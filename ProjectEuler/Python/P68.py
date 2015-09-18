from itertools import permutations
from project_euler import *

def find_magic(centerRing :list):
    results = []
    n = len(centerRing)
    notUsedNumbers = set(range(1, 2 * n + 1)).difference(set(centerRing))
    externalRingsToCheck = permutations(notUsedNumbers)
    magicExternalRings = []

    for externalRing in externalRingsToCheck:
        isMagic = True
        sum = externalRing[0] + centerRing[0] + centerRing[1]
        
        for i in range(n):
            if externalRing[i] + centerRing[i] + centerRing[(i + 1) % n] != sum:
                isMagic = False

        if isMagic:
            magicExternalRings.append(externalRing)

    return magicExternalRings

def solution_set(centerRing, externalRing):
    # starting at min external ring element
    startIndex = externalRing.index(min(externalRing))
    n = len(centerRing)

    result = []

    for i in range(startIndex, startIndex + n):
        result.append( [externalRing[i % n], centerRing[i % n], centerRing[(i + 1) % n]] )

    return result


n = 5
solutions_to_check_exists = set()

for centralRing in permutations([x + 1 for x in range(n * 2)], n):
    magicExternalRings = find_magic(centralRing)

    for x in magicExternalRings:
        s_set = solution_set(centralRing, x)
        s_set_string = "".join([str(x) for x in flatten(s_set)])

        if not s_set_string in solutions_to_check_exists:
            solutions_to_check_exists.add(s_set_string)
            print("{4} c: {0}, e: {1}, s. set: {2}, sum: {3}".format(centralRing, x, s_set, sum(s_set[0]), s_set_string))

