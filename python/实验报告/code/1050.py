import math
N = int(input())
A = list(map(int, input().split()))
A.sort(reverse=True)
# 计算m,n
num = math.sqrt(N)
if num % 1 == 0:
    m = n = int(num)
else:
    m = int(num)+1
    while N % m != 0:
        m += 1
    n = N//m


class pos:
    '''位置类'''
    direct = ['r', 'd', 'l', 'u']

    def __init__(self, x, y, direct='r'):
        self.x = x
        self.y = y
        self.direct = direct

    def next(self):
        '''返回新的位置对象'''
        if self.direct == 'r':
            return pos(self.x+1, self.y, self.direct)
        elif self.direct == 'd':
            return pos(self.x, self.y+1, self.direct)
        elif self.direct == 'l':
            return pos(self.x-1, self.y, self.direct)
        elif self.direct == 'u':
            return pos(self.x, self.y-1, self.direct)

    def nextDirect(self):
        '''设置下一个方向'''
        self.direct = pos.direct[(pos.direct.index(self.direct)+1) % 4]


ans = [[0]*n for i in range(m)]
now = pos(0, 0)

for item in A:
    ans[now.y][now.x] = item
    next_pos = now.next()
    if next_pos.x >= n or next_pos.y >= m or ans[next_pos.y][next_pos.x] != 0:
        now.nextDirect()
        now = now.next()
    else:
        now = next_pos
for row in ans:
    print(*row)