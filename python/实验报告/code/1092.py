N, M = map(int, input().split())
lst = []
for i in range(M):
    lst.append(list(map(int, input().split())))
a = [sum([lst[i][j] for i in range(M)]) for j in range(N)]
max_chengshi = max(a)
ans = []
for i in range(len(a)):
    if a[i] == max_chengshi:
        ans.append(i+1)
print(max_chengshi)
print(*ans)