N, M = map(int, input().split())
chajiao = input().split()


def shaixuan(a, b):
    '''筛选b中在a中的元素'''
    c = []
    for i in b:
        if i in a:
            c.append(i)
    return c


a, b = 0, 0
for i in range(N):
    name, *wupin = input().split()
    l = shaixuan(chajiao, wupin)
    if len(l) > 0:
        print(name+':', *l)
        a += 1
        b += len(l)
print(a, b)