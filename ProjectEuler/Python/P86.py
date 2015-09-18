import math
import binary_search

#def shortest_cuboid_path(a, b, c):
    
#    (a, b, c) = sorted( [ a, b, c ], reverse=True )

#    return math.sqrt( a ** 2 + (b + c) ** 2 )

def primitive_pythagorian(max_catet):

    result = []

    for r in range(2, math.ceil( math.sqrt( max_catet ) )):
        
        for s in range(1, max_catet // (2 * r)):

            a = r ** 2 - s ** 2
            b = 2 * r * s
            c = r ** 2 + s ** 2

            if a <= max_catet and b <= max_catet:
                #yield [max(a, b), min(a, b)]
                result.append( [max(a, b), min(a, b)] )

    return result

def pythagorian_catets(max_catet):

    res = set()

    for ab in primitive_pythagorian(max_catet):

        for mult in range(1, 10 ** 10):

            if ab[0] * mult > max_catet or ab[1] * mult > max_catet:
                break

            res.add( (ab[0] * mult, ab[1] * mult) )

    return sorted( res )

def __lwh(l, wh_sum, M):
    
    r = []

    for h in range(1, 1 + wh_sum // 2):
        w = wh_sum - h

        if max(w, h) > l:
            continue

        m = 0
        while True:
            m += 1

            if l * m > M or w * m > M or h * m > M:
                break

            t = ( l * m, w * m, h * m)

            r.append( t )

    return r

def num_of_integer_solutions(M):
    
    s = []

    for p in pythagorian_catets(2 * M):
        
        s += __lwh(p[0], p[1], M)
        s += __lwh(p[1], p[0], M)

    return len( set(s) )


#print( len(pythagorian_catets(1000 * 2)) )
M = 1818
print( "{0} -> {1}".format(M, num_of_integer_solutions(M) ) )