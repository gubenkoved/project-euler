import project_euler
import math

max = 50 * 10 ** 6

primes = project_euler.eratosphen_primes( math.sqrt( max ) )

values = set()

done = 0
for p_sq in primes:
    
    done += 1
    project_euler.report_progress( done / len(primes) )

    for p_cube in primes:

        if p_sq ** 2 + p_cube ** 3 > max: break

        for p_dsq in primes:
            
            v = p_sq ** 2 + p_cube ** 3 + p_dsq ** 4

            if v < max: values.add( v )
            else: break

print( len(values) )