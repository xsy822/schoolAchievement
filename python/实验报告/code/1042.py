def getMore(s):
    d = {}
    for i in s:
        if i.isalpha():
            i = i.lower()
            if i in d:
                d[i] += 1
            else:
                d[i] = 1
    max_key = max(d.items(), key=lambda x: (x[1], -ord(x[0])))[0]
    return max_key, d[max_key]


print(*getMore(input()))