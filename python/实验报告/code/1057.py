def fun(num: str) -> int:
    '''统计num中0,1个数'''
    a, b = 0, 0
    for i in num:
        if i == '0':
            a += 1
        else:
            b += 1
    return a, b


s = input()
ans = 0
for i in s:
    if i.isalpha():
        num = ord(i.lower())-ord('a')+1
        ans += num
if ans == 0:
    print(0,0)
    exit()
print(*fun(bin(ans)[2:]))