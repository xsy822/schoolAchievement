N = int(input())
ans = 0
d = {}
for i in range(1, N+1):
    temp = i//2+i//3+i//5
    if not temp in d:
        d[temp] = 1
        ans += 1
print(ans)