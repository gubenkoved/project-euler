def find_inc( func, predicate, start, end):
    "Finds first value of X in [start; end) that meets predicate"

    print ("BS in range: [{0}, {1})".format(start, end) )

    if end - start == 1 and predicate( func( end ) ):

        print ("BS results: x = {0}, func(x) = {1}".format( end, func( end ) ))

        return end

    center = (start + end) // 2

    if not predicate( func( center ) ):
        return find_inc( func, predicate, center, end )
    else:
        return find_inc( func, predicate, start, center)

