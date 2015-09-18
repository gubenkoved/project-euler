import project_euler
from functools import lru_cache
from random import randint
from random import shuffle

board = ["go", "a1", "cc1", "a2", "t1", "r1", "b1", "ch1", "b2", "b3",
         "jail", "c1", "u1", "c2", "c3", "r2", "d1", "cc2", "d2", "d3",
         "fp", "e1", "ch2", "e2", "e3", "r3", "f1", "f2", "u2", "f3",
         "g2j", "g1", "g2", "cc3", "g3", "r4", "ch3", "h1", "t2", "h2"]

# actions
def noop(p: int):
    return p

@lru_cache(maxsize=None)
def g2sq(sq: str):
    return next(i for i, x in enumerate(board) if x == sq)

@lru_cache(maxsize=None)
def g2nsq(p :int, sqprefix: str):
    return (lambda p: next(i % len(board) for i in range(p+1, p + len(board)) if board[i % len(board)].startswith(sqprefix)))(p)

def g2g(p): return g2sq("go")
def g2j(p): return g2sq("jail")
def g2c1(p): return g2sq("c1")
def g2e3(p): return g2sq("e3")
def g2h2(p): return g2sq("h2")
def g2r1(p): return g2sq("r1")
def g2nr(p): return g2nsq(p, "r")
def g2nu(p): return g2nsq(p, "u")
def g2back(p): return p - 3

##
cc_capacity = 16
ch_capacity = 16

## cc init
cc = [ g2g, g2j ]
cc += [ noop ] * (cc_capacity - len(cc))

# ch init
ch = [g2g, g2j, g2c1, g2e3, g2h2, g2r1, g2nr, g2nr, g2nu, g2back]
ch += [ noop ] * (ch_capacity - len(ch))

# game dynamic
def roll_dice(max):
    return randint(1, max)

def roll_dices(n: int, max: int):
    return sum(roll_dice(max) for x in range(n))

def shuffle_(arr):
    shuffle(arr)
    return arr

def take_card(pile):
    card = pile[0]
    new_pile = pile[1:] + [card]

    for i in range(len(pile)):
        pile[i] = new_pile[i]

    return card

rolls_history = []

def is_three_doubles(rolls_history, double_score):
    if len(rolls_history) >= 3:
        return sum(rolls_history[-3:]) == 3 * double_score

# game variables
max_dice = 4
stats = [0] * len(board)

def setup_simulation():
    global cc
    global ch

    cc = shuffle_(cc)
    ch = shuffle_(ch)

def simulate(max_steps: int):
    global stats
    global rolls_history

    position = 0
    stats[0] += 1
    step = 1

    while True:

        if (step > max_steps):
            break

        roll = roll_dices(2, max_dice)
        #rolls_history += [ roll ]

        if is_three_doubles(rolls_history, 2 * max_dice):
            new_position = g2j(position)
            #print( "slow down!" )
        else:
            new_position = position + roll
            new_position = new_position % len(board)

            # community chest
            if board[new_position].startswith("cc"):
                card = take_card(cc)
                #print( "CC: {0}".format(card) )
                new_position = card(new_position)

            # chance
            if board[new_position].startswith("ch"):
                card = take_card(ch)
                #print( "CH: {0}".format(card) )
                new_position = card(new_position)

            if new_position == 30: # go to jail
                new_position = g2j(new_position)

        new_position = new_position % len(board)
        stats[new_position] += 1

        position = new_position

        step += 1

        pass

for i in range(100):
    print ( "Simulation #{0}".format(i) )
    setup_simulation()
    simulate(1000)

#print(stats)
s = sum(stats)
print( sorted([(x/s, i, board[i]) for (i, x) in enumerate(stats)], key=lambda x: x[0], reverse=True) )