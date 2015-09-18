import math
import project_euler

def checkOnRightTriangle(P, Q):
    a = P[0] ** 2 + P[1] ** 2
    b = Q[0] ** 2 + Q[1] ** 2
    c = (P[0] - Q[0]) ** 2 + (P[1] - Q[1]) ** 2

    (a, b, c) = sorted([a, b, c])

    return c == a + b

n = 50
r = 0

for x1 in range(n + 1):

    project_euler.report_progress( x1 / n )

    for y1 in range(n + 1):
        for x2 in range(n + 1):
            for y2 in range(n + 1):

                if x1 == 0 and y1 == 0 or x2 == 0 and y2 == 0:
                    continue

                if x1 == x2 and y1 == y2:
                    continue

                if checkOnRightTriangle( (x1, y1), (x2, y2) ):
                    r += 1

print( r // 2 ) 