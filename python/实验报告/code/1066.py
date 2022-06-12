M, N, A, B, C = input().split()
A = A.rjust(3, '0')
B = B.rjust(3, '0')
C = C.rjust(3, '0')
M = int(M)
N = int(N)
ans = []
for _ in range(M):
    p = [i.rjust(3, '0') for i in input().split()]
    for i in range(N):
        if A <= p[i] <= B:
            p[i] = C
    print(*p)
