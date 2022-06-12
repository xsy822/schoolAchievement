N, D = map(int, input().split())
a = map(float, input().split())
b = map(float, input().split())
x = list(zip(a, b))
x.sort(key=lambda x: x[1] / x[0], reverse=True)
ans = 0
for i in x:
    if i[0] <= D:
        D -= i[0]
        ans += i[1]
    else:
        ans += D * (i[1] / i[0])
        break
print('{:.2f}'.format(ans))