ls = list(map(int, input().split(' ')))
ans = []
for i in range(0, len(ls), 2):
    a = ls[i]*ls[i+1]
    b = ls[i+1]-1
    if a != 0:
        ans.append(a)
        ans.append(b)

print(' '.join(map(str, ans if ans != [] else [0, 0])))