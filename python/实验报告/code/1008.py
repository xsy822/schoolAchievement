n, m = (int(i)for i in input().split())
a = [int(i)for i in input().split()]
for i in range(0, m):
    t = a[-1]
    for j in range(0, n):
        a[j], t = t, a[j]
for i in a[0:n-1]:
    print(i, end=' ')
print(a[n-1])