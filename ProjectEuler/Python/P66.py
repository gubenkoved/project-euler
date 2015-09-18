from project_euler import *
import math
import sqrt_expansion

solution = { 'answer': -1, 'D': -1 }

for D in range(2, 1001):
    if is_square(D): continue

    n = 0
    while True:
        n += 1
        
        convergent = sqrt_expansion.continued_fraction(D, n).evaluate()
        y = convergent.denominator

        x_sq = 1 + D * y ** 2

        if is_square(x_sq):
            x = maximal_root(x_sq)
            
            if x > solution['answer']:
                solution['answer'] = x
                solution['D'] = D

            correct = (x ** 2 - D * y ** 2 == 1)

            print("{3:6} {0:40d}^2 - {1:4d}*{2:40d}^2 = 1".format(x, D, y, 'OK' if correct else 'FAIL'))
            break

print(solution)