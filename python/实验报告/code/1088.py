def compare(l, m, n):
    if m == n:
        l.append('Ping')
    elif m < n:
        l.append('Cong')
    else:
        l.append('Gai')
    return l


M, X, Y = [int(i) for i in input().split()]
rst = []
for i in range(99, 9, -1):
    a = i
    b = int(str(i)[::-1])
    c = abs(a-b)/X
    if c*Y == b:
        rst.append(str(a))
        rst = compare(rst, M, a)
        rst = compare(rst, M, b)
        rst = compare(rst, M, c)
        print(*rst)
        exit()
print('No Solution')