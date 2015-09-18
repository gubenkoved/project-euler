sudokus = []

def print_sudoku(sudoku):

    for l in sudoku:
        print( l )

    print( '---' )

def solve(sudoku):

    # find first zero
    x = None
    y = 0

    for line in sudoku:

        if 0 in line:
            x = line.index(0)
            break

        y += 1

    # check for end
    if x is None:
        print('Solved!')
        return True

    used = set()

    # in square
    x_sq = (x // 3) * 3
    y_sq = (y // 3) * 3
    
    for i in range(9):
        for j in range(9):
            # take all in row, column and square
            if i == y \
                or j == x \
                or (i >= y_sq and i < y_sq + 3 and j >= x_sq and j < x_sq + 3):

                used.add(sudoku[i][j])

    if 0 in used:
        used.remove( 0 )
            
    # check for end when wrong path
    if len( used ) == 9:
        return False

    # try each possible num in the square
    for p in set( range(1, 10) ).difference(used):
        sudoku[y][x] = p

        if solve( sudoku ): # recursion step
            return True

        sudoku[y][x] = 0

    #raise Exception("Not solvable sudoku!")
    return False

with open('files/p096_sudoku.txt', 'r') as data_file:

    while True:
        l = data_file.readline()

        sudoku = []
        for n in range(9):
            sudoku.append( [int(x) for x in list(data_file.readline())[:9]] )

        if len( l ) == 0: break

        sudokus.append( sudoku )
        #print_sudoku( sudoku )


n = 1
s = 0
for sudoku in sudokus:
    solve( sudoku )
    
    print( n )
    print_sudoku( sudoku )

    s += int("".join([ str(x) for x in sudoku[0][:3] ]))
    n += 1

print( s )