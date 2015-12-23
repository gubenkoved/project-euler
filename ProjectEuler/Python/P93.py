
def par_sets(s_full: str, i: int = None, j: int = None):
    if i is None: i = 0
    if j is None: j = len(s_full)

    s = s_full[i:j]
    n = len(s)

    for start in range(n - 1):
        for end in range(start + 2, n + 1):

            if end - start == j - i:
                continue

            new_sub_string = add_par(s, start, end)
            new_s_full= s_full[:i] + new_sub_string + s_full[j:]

            print(new_s_full)

            if end - start > 2:
                par_sets(new_s_full, start + 1, end + 1)
    pass

def add_par(s: str, start: int, end: int):
    s_before_start = s[:start]
    s_inside = s[start:end]
    s_after_end = s[end:]

    return "{0}({1}){2}".format(s_before_start, s_inside, s_after_end)

#print(add_par("testing", 1, 4))

print(par_sets("1234"))

