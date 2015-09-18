class P2D:
    x = None
    y = None

    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __str__(self):
        return "({0}, {1})".format(self.x, self.y)

    def __repr__(self):
        return str(self)

    def __hash__(self):
        return self.x ^ self.y

    def __eq__(self, other):
        return self.x == other.x and self.y == other.y

#with open('files/p082_matrix_test.txt', 'r') as data_file:
with open('files/p082_matrix.txt', 'r') as data_file:
    matrix = [[int(x) for x in line.split(',')] for line in data_file ]

def get_neighbors(matrix, point):
    N = len(matrix)
    
    if point.x < N - 1:
        yield P2D(point.x + 1, point.y)

    if point.y < N - 1:
        yield P2D(point.x, point.y + 1)

    if point.y > 0:
        yield P2D(point.x, point.y - 1)

def get_point_by_predicate(matrix, predicate):
    r = []
    for y in range(len(matrix)):
        for x in range(len(matrix[y])):
            if predicate(matrix[y][x]):
                r.append( P2D(x, y) )
    return r

def find_shortest_part(matrix):
    
    N = len(matrix)
    # info will store the info data structure (dictionary) for each cell
    info = [[ { 'path': None, 'd': 10 ** 9 } for x in range(N)] for x in range(N)]

    for i in range(N):
        info[i][0]['d'] = matrix[i][0]
        info[i][0]['path'] = []

    not_visited = []

    for y in range(len(matrix)):
        for x in range(len(matrix[y])):
            not_visited.append( P2D(x, y) )

    while True:

        rest = sorted(not_visited, key=lambda p: info[p.y][p.x]['d'])

        print(len(rest))

        if len(rest) == 0: break # all is visited

        current = rest[0]

        neighbors = list(get_neighbors(matrix, current))

        for neighbor in neighbors:
            dist = info[current.y][current.x]['d'] + matrix[neighbor.y][neighbor.x]

            if info[neighbor.y][neighbor.x]['d'] > dist: # found shorter way
                
                info[neighbor.y][neighbor.x]['d'] = dist
                info[neighbor.y][neighbor.x]['path'] = list(info[current.y][current.x]['path']) + [ P2D(current.x, current.y) ]

        not_visited.remove( current )


    min_d = None

    for y in range(N):

        cur_d = info[y][N - 1]['d']

        if min_d is None or cur_d < min_d:
            min_d = info[y][N - 1]['d']
            min_path = info[y][N - 1]['path'] + [ P2D(N-1, y) ]

    print ("MIN distance: {0}, PATH: {1}".format(min_d, min_path))


find_shortest_part(matrix)