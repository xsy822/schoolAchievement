x = int(input())
ans = 0
while x != 1:
    x = x//2 if x % 2 == 0 else (x*3+1)//2
    ans += 1
print(ans)