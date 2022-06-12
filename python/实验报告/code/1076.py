N = int(input())
ans = []
for i in range(N):
    a = ['A', 'B', 'C', 'D']
    b = input().split()
    for j in range(len(b)):
        if b[j][2] == 'T':
            ans.append(a.index(b[j][0])+1)
print(*ans, sep='')