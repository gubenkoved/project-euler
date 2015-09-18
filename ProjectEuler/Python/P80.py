import math
import project_euler
import sqrt_expansion
from fractions import Fraction

def sqrt_fraction_part_with_custom_persicion(x, target_presicion):
    terms_amount = 1
    
    while True:
        terms_amount += 5
        expansion = sqrt_expansion.continued_fraction(x, terms_amount)
        evaluated = expansion.evaluate()
        denom_len = math.floor(math.log10(evaluated.denominator))

        f_part = int ( evaluated * Fraction( 10 ** denom_len ) )

        if f_part > 0 and math.log10(f_part) > target_presicion:
            return f_part

result = 0

for x in range(2, 100 + 1):
    if not project_euler.is_square(x):
        e = sqrt_fraction_part_with_custom_persicion(x, 100)
        print("sqrt({0}) -> {1} ({2} digits)".format(x, e, len(str(e))))

        result += sum( [ int(d) for d in list(str(e)[:100]) ] )

        print ("Current sum: {0}".format(result))