input()
l = [int(i) for i in input().split()]
d = {}
for i in range(len(l)):
    sub = abs(l[i]-(i+1))
    d[sub] = d.get(sub, 0)+1
d = list(filter(lambda x: x[1] > 1, d.items()))
d = sorted(d, reverse=True)
for i in d:
    print(*i)