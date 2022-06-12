n = int(input())
a, b = 0, 0
for i in range(n):
    a1, a2, b1, b2 = map(int, input().split())
    if a2 != b2:
        if a2 == a1+b1:
            b += 1
        elif b2 == a1+b1:
            a += 1
print(a, b)