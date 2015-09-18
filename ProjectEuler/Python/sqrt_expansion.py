import math

class SqrtExpansionTerm:
    """ term = a + 1 / (m  / (sqrt(...) - n)) """
    a = 0
    n = 0
    m = 0

    def __init__(self, a, m, n):
        self.a = a
        self.n = n
        self.m = m

    def __eq__(self, other):
        return self.a == other.a and self.m == other.m and self.n == other.n

    def __hash__(self):
        return hash(self.a)

class ContinuedFraction:
    a0 = 0
    a = []

    def __init__(self, a0, a):
        self.a0 = a0
        self.a = a

    def __str__(self):
        return "[{0}, {1}]".format(self.a0, self.a)

    def evaluate(self):
        from fractions import Fraction

        if len(self.a) == 0: return self.a0

        current = Fraction(self.a[-1])

        for i in reversed(range(len(self.a) - 1)):
            current = self.a[i] + Fraction(1) / current

        return Fraction(1) / current + self.a0

def continued_fraction_terms_gen(x):
    """ Evaluates continued fraction [A0, A1, A2, ..., An] for sqrt(x) """
    a0 = math.floor(math.sqrt(x))
    previous = SqrtExpansionTerm(a0, 1, a0)

    yield previous
    while True:
        gcd = x - previous.n * previous.n
        gcd = gcd // previous.m
        surplus = previous.n
        a = math.floor((math.sqrt(x) + surplus) / gcd)
        previous = SqrtExpansionTerm(a, gcd, -1 * (surplus - a * gcd))
        yield previous

def continued_fraction_gen(x):
    import itertools
    gen = continued_fraction_terms_gen(x)
    a0 = next(gen).a
    a = []

    for term in gen:
        yield ContinuedFraction(a0, a)
        a.append( term.a )


def continued_fraction(x, n):
    import itertools

    return next(itertools.islice(continued_fraction_gen(x), n, n + 1))

def repeated_continued_fraction(x):
    gen = continued_fraction_terms_gen(x)
    a0 = next(gen)
    period = []

    for term in gen:

        if term in period: # found cycle
            return ContinuedFraction(a0.a, [x.a for x in period]) 

        period.append(term)

def convergents_gen(x):
    for con_frac in continued_fraction_gen(x):
        yield con_frac.evaluate()