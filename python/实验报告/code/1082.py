n = int(input())
lst = []
for i in range(n):
    id, x, y = input().split()
    x, y = int(x), int(y)
    lst.append([id, x, y])
# lst按二维点(x,y),与(0,0)的距离排序
lst.sort(key=lambda x: x[1]**2+x[2]**2)
print(lst[0][0], lst[-1][0])