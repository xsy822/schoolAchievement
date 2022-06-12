n = int(input())
d = {}
for i in range(n):
    a, score = input().split()
    a = a.split('-')[0]
    score = int(score)
    d[a] = d.get(a, 0)+score
# d按照value排序
d = sorted(d.items(), key=lambda x: x[1], reverse=True)
print(*(d[0]))