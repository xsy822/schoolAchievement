A, B, D = map(int, input().split())
A = A+B
ans = []
if A!=0:
    while A != 0:
        ans.append(A % D)
        A //= D
    print(*ans[::-1], sep='')
else:
    print(0)