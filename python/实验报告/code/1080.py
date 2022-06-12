P, M, N = map(int, input().split())
students = {}
for i in range(P):
    s = input().split()
    if s[0] not in students:
        students[s[0]] = {}
    students[s[0]]['P'] = int(s[1])
for i in range(M):
    s = input().split()
    if s[0] not in students:
        students[s[0]] = {}
    students[s[0]]['M'] = int(s[1])
for i in range(N):
    s = input().split()
    if s[0] not in students:
        students[s[0]] = {}
    students[s[0]]['N'] = int(s[1])
res = []
for i in students:
    Gp = students[i].get('P', -1)
    Gm = students[i].get('M', -1)
    Gfinal = students[i].get('N', -1)
    if Gm > Gfinal:
        G = int(Gm*0.4+Gfinal*0.6+0.5)
    else:
        G = Gfinal
    res.append([i, Gp, Gm, Gfinal, G])
res = list(filter(lambda x: x[1] >= 200 and x[-1] >= 60, res))
# res按G递减排序，G相同按i递增排序
res.sort(key=lambda x: (-x[-1], x[0]))
for i in res:
    print(*i)