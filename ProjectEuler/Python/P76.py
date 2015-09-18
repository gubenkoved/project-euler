def next_way(l, n):
    if l[0] == n - 1:
        return None

    v = l[-2] + 1
    
    l_sum = 0
    for index in range(0, len(l)):
        if l[index] < v:
            break
        else:
            l_sum += l[index]

    return l[:index] + [v] + [1] * (n - l_sum - v)

def all_ways(sum):
    count = 0
    l = [1] * sum

    while True:
        #print("+".join([str(x) for x in l]))
        
        count += 1

        if count % 10000 == 0:
            print(count)
            print("+".join([str(x) for x in l]))

        l = next_way(l, sum)

        if l is None:
            break

    print ("Count: {0}".format(count))

all_ways(100)