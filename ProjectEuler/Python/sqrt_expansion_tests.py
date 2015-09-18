import unittest
from sqrt_expansion import *

class Test_sqrt_expansion_tests(unittest.TestCase):
    def test_continued_fraction_1(self):
        cf = continued_fraction(23, 0)

        self.assertEqual(cf.a0, 4)
        self.assertEqual(cf.a, [])

    def test_continued_fraction_2(self):
        cf = continued_fraction(23, 1)

        self.assertEqual(cf.a0, 4)
        self.assertEqual(cf.a, [1])

    def test_continued_fraction_3(self):
        cf = continued_fraction(23, 4)

        self.assertEqual(cf.a0, 4)
        self.assertEqual(cf.a, [1, 3, 1, 8])

    def test_continued_fraction_evaluation_1(self):
        from fractions import  Fraction

        cf = ContinuedFraction(0, [2])

        self.assertEqual(cf.evaluate(), Fraction(1, 2))

    def test_continued_fraction_evaluation_2(self):
        from fractions import  Fraction

        cf = continued_fraction(23, 4)

        self.assertEqual(cf.evaluate(), Fraction(211, 44))

    def test_continued_fraction_evaluation_3(self):
        from fractions import  Fraction

        cf = continued_fraction(23, 5)

        self.assertEqual(cf.evaluate(), Fraction(235, 49))

if __name__ == '__main__':
    unittest.main()
