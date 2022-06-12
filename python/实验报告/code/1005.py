n = int(input())
A = list(map(int, input().split(' ')))
B = []
for i in range(n):
    x = A[i]
    ans = 0
    while x != 1:
        x = x//2 if x % 2 == 0 else (x*3+1)//2
        if x in B:
            break
        B.append(x)
        ans += 1
print(" ".join(str(i) for i in sorted(list(set(A)-set(B)), reverse=True)))