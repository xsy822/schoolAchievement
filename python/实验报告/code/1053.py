N, e, D = map(float, input().split())
N, D = int(N), int(D)
a, b = 0, 0
for _ in range(N):
    lst = list(map(float, input().split()))[1:]
    days = 0
    for i in lst:
        if i < e:
            days += 1
    if days > len(lst)/2:
        if len(lst) > D:
            b += 100
        else:
            a += 100
print('{:.1f}% {:.1f}%'.format(a/N, b/N))