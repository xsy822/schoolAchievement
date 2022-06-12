n = int(input())
d = {}
for i in range(n):
    a = input().split()
    d[a[1]] = [a[0], a[2]]
input()

a = input().split()
for i in a:
    if i in d:
        print(*d[i])