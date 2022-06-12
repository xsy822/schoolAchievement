def Insertion_Sort(n, m):
    f = 0
    for i in range(len(n) - 1):
        l = n[:i + 2]
        l.sort()
        rst = l + n[i + 2:]
        if f == 1:
            rst = [str(i) for i in rst]
            print('Insertion Sort')
            print(' '.join(rst))
            exit()
        if rst == m:
            f = 1


def Merge_Sort(n, m):
    n = [[i] for i in n]
    f = 0
    while len(n) > 1:
        tmp = []
        rst = []
        if len(n) % 2 == 0:
            for i in range(0, len(n), 2):
                s = n[i] + n[i + 1]
                s.sort()
                tmp.append(s)
            n = tmp
        else:
            for i in range(0, len(n) - 1, 2):
                s = n[i] + n[i + 1]
                s.sort()
                tmp.append(s)
            tmp.append(n[-1])
            n = tmp
        for i in n:
            rst += i
        if f == 1:
            rst = [str(i) for i in rst]
            print('Merge Sort')
            print(' '.join(rst))
            exit()
        if rst == m:
            f = 1


input()
n1 = [int(i) for i in input().split()]
n2 = n1[:]
m = [int(i) for i in input().split()]
Insertion_Sort(n1, m)
Merge_Sort(n2, m)