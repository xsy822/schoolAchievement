import math


def isPrime(n):
    if n == 2 or n == 3:
        return True
    if n % 2 == 0 or n % 3 == 0:
        return False
    for k in range(6, int(math.sqrt(n)+2), 6):
        if n % (k+1) == 0 or n % (k-1) == 0:
            return False
    return True


n = int(input())
ans = 0
suShu = [i for i in range(2, n+1) if isPrime(i)]
for i in range(len(suShu)-1):
    if suShu[i+1]-suShu[i] == 2:
        ans += 1
print(ans)