import re
n = int(input())
for i in range(n):
    temp = input()
    if re.match(r'A*PA+TA*', temp):
        a = re.split(r'[P|T]', temp)
        if a[0]*len(a[1]) == a[2]:
            print('YES')
        else:
            print('NO')
    else:
        print('NO')