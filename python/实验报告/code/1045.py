input()
n = [int(i) for i in input().split()]
l = []
m = 0
for i in n:
    if not l:
        if i < m:
            continue
        l.append(i)
        m = i
    elif i > l[-1]:
        if i < m:
            continue
        l.append(i)
        m = i
    while True:
        if i < l[-1]:
            del l[-1]
        if not l:
            break
        elif i >= l[-1]:
            break
print(len(l))
print(*l)